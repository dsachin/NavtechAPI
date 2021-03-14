using ApiModels.Models;
using ApiModels.Models.MultiModel;

using ApiService.Helper;

using Navtech.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ApiService.Service
{
    public class OrderService : BaseService, IOrderService
    {
        string dbConnStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        public ApiResultModel<dynamic> GetOrders(int pageIndex, int pageSize, bool isSortedByAscending = true)
        {
            ApiResultModel<dynamic> apiResult = new ApiResultModel<dynamic>();
            try
            {
                if (pageIndex > 0 && pageSize > 0)
                {
                    string sorting = isSortedByAscending ? ApiConstants.SortByAscending : ApiConstants.SortByDescending;
                    using (SqlConnection connection = new SqlConnection(dbConnStr))
                    {
                        SqlCommand sqlcom = new SqlCommand(ApiConstants.P_GetOrderDetails, connection);
                        sqlcom.Parameters.Add(SetParameter("Size", pageSize, SqlDbType.Int, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("Page", pageIndex - 1, SqlDbType.Int, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("Sort", sorting, SqlDbType.NVarChar, ParameterDirection.Input));

                        DataSet ds = ExecuteStoredProcedure(connection, sqlcom);

                        if (ds != null)
                        {
                            apiResult = new ApiResultModel<dynamic>();
                            if (ds.Tables[0].Rows.Count >= 1)
                            {
                                List<OrderResponseModel> orders = ds.Tables[0].ToList<OrderResponseModel>();
                                apiResult = PrepareReturnResult(ApiConstants.DataFetchedSuccessfully, isSuccess: true);
                                apiResult.Data = orders;
                            }
                            else
                            {
                                apiResult = PrepareReturnResult(ApiConstants.NoOrdersFound, isSuccess: true);
                            }
                        }
                    }
                }
                else
                {
                    apiResult = PrepareReturnResult(ApiConstants.InvalidPageInput);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResult;
        }

       
        public ApiResultModel<dynamic> CreateOrder(OrderProductModel orderDetails)
        {
            ApiResultModel<dynamic> apiResult;
            try
            {
                List <OrderProductMappingViewModel> products = JsonConvert.DeserializeObject<List<OrderProductMappingViewModel>>(orderDetails.Products);

                if (orderDetails != null && products.Count > 0)
                {
                    DataTable dt = GetProductDetailsInDatatable(products);
                    using (SqlConnection connection = new SqlConnection(dbConnStr))
                    {
                        SqlCommand sqlcom = new SqlCommand(ApiConstants.P_InsertOrderDetails, connection);
                        sqlcom.Parameters.Add(SetParameter("@OrderProductsMapping", dt, SqlDbType.Structured, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("CustomerId", orderDetails.CustomerId, SqlDbType.Int, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("OrderStatusId", orderDetails.OrderStatusId, SqlDbType.Int, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("Amount", orderDetails.Amount, SqlDbType.Float, ParameterDirection.Input));
                        sqlcom.Parameters.Add(SetParameter("PaymentTypeId", orderDetails.PaymentTypeId, SqlDbType.Int, ParameterDirection.Input));

                        DataSet ds = ExecuteStoredProcedure(connection, sqlcom);

                        if (!(bool)ds.Tables[0].Rows[0]["Result"])
                        {
                            return PrepareReturnResult(Convert.ToString(ds.Tables[0].Rows[0]["ErrorMessage"]), Convert.ToString(ds.Tables[0].Rows[0]["ErrorCode"]));
                        }
                    }
                    apiResult = PrepareReturnResult(ApiConstants.OrderCreatedSuccessfully, isSuccess: true);
                }
                else
                {
                    apiResult = PrepareReturnResult(ApiConstants.InvalidOrderDetails);
                }
            }
            catch(JsonReaderException)
            {
                apiResult = PrepareReturnResult(ApiConstants.InvalidProductDetails);
            }
            catch (Exception)
            {
                throw;
            }
            return apiResult;
        }

        private static DataTable GetProductDetailsInDatatable(List<OrderProductMappingViewModel> orderDetails)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("OrderId", typeof(int)));
            dt.Columns.Add(new DataColumn("ProductId", typeof(int)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dt.Columns.Add(new DataColumn("CreatedDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));

            foreach (OrderProductMappingViewModel order in orderDetails)
            {
                dt.Rows.Add(order.OrderId, order.ProductId, order.Quantity, DateTime.Now, DateTime.Now);
            }

            return dt;
        }


        private static DataSet ExecuteStoredProcedure(SqlConnection connection, SqlCommand sqlcom)
        {
            DataSet ds;
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlcom))
            {
                try
                {
                    ds = new DataSet();
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
            return ds;
        }



        private SqlParameter SetParameter(string parameterName, object parameterValue, SqlDbType dbType, ParameterDirection Direction = ParameterDirection.Input, string typeName = "")
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = parameterName;

            if (parameterValue == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = parameterValue;
            }
            parameter.SqlDbType = dbType;
            parameter.Direction = Direction;
            if (!string.IsNullOrEmpty(typeName))
            {
                parameter.TypeName = typeName;
            }
            return parameter;
        }
    }
}
