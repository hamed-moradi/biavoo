using Dapper;
using domain.utility;
using domain.utility._app;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace domain.application._app {
    public interface IStoreProcedure<Result, Schema> {
        //Sync
        void ExecuteReturnLess(string procedure);
        void ExecuteReturnLess(Schema model);
        IEnumerable<Result> Execute(string procedure);
        IEnumerable<Result> Execute(Schema model);
        Result ExecuteFirstOrDefault(string procedure);
        Result ExecuteFirstOrDefault(Schema model);

        //Async
        Task ExecuteReturnLessAsync(string procedure);
        Task ExecuteReturnLessAsync(Schema model);
        Task<IEnumerable<Result>> ExecuteAsync(string procedure);
        Task<IEnumerable<Result>> ExecuteAsync(Schema model);
        Task<Result> ExecuteFirstOrDefaultAsync(string procedure);
        Task<Result> ExecuteFirstOrDefaultAsync(Schema model);
    }
    public class StoreProcedure<Result, Schema>: IStoreProcedure<Result, Schema>
        where Result : IBaseModel
        where Schema : IBaseSchema {
        #region Constructor
        private readonly IRepository<Result> _repository;
        public StoreProcedure(IRepository<Result> repository) {
            _repository = repository;
        }
        #endregion
        #region Private
        private DynamicParameters MakeParameters(Schema schema) {
            var parameters = new DynamicParameters();
            var inputProperties = schema.GetType().GetProperties().Where(item => Attribute.IsDefined(item, typeof(InputParameter)));
            foreach(var item in inputProperties) {
                var key = item.Name;
                var value = item.GetValue(schema, null);
                var attrs = item.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is InputParameter input && !string.IsNullOrWhiteSpace(input.Name))
                        key = input.Name;
                }
                if(item.PropertyType.Name.Contains("IEnumerable")) {
                    var genericType = item.PropertyType.GetGenericArguments().Single();
                    var genericTypeName = genericType.Name;
                    var genericTypeAttrs = genericType.GetCustomAttributes(true);
                    foreach(var attr in genericTypeAttrs) {
                        if(attr is System.ComponentModel.DataAnnotations.Schema.TableAttribute table && !string.IsNullOrWhiteSpace(table.Name))
                            genericTypeName = table.Name;
                    }
                    var dataTable = new DataTable(genericTypeName);
                    foreach(var column in genericType.GetProperties())
                        dataTable.Columns.Add(column.Name);
                    var list = (System.Collections.IEnumerable)item.GetValue(schema);
                    foreach(var row in list) {
                        var genericTypeProps = row.GetType().GetProperties();
                        var dataRow = dataTable.NewRow();
                        for(var i = 0; i < dataTable.Columns.Count; i++)
                            dataRow[i] = genericTypeProps[i].GetValue(row);
                        dataTable.Rows.Add(dataRow);
                    }
                    parameters.Add(key, dataTable.AsTableValuedParameter(genericTypeName), DbType.Object, direction: ParameterDirection.Input);
                }
                else
                    parameters.Add(key, value, item.PropertyType.ToDbType(), direction: ParameterDirection.Input);
            }
            var outputProperties = schema.GetType().GetProperties()?.Where(item => Attribute.IsDefined(item, typeof(OutputParameter)));
            foreach(var item in outputProperties) {
                var key = item.Name;
                var attrs = item.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is OutputParameter output && !string.IsNullOrWhiteSpace(output.Name))
                        key = output.Name;
                }
                parameters.Add(key, dbType: item.PropertyType.ToDbType(), direction: ParameterDirection.Output);
            }
            return parameters;
        }
        private void SetOutputValues(Schema model, DynamicParameters parameters) {
            var outputProperties = model.GetType().GetProperties().Where(item => Attribute.IsDefined(item, typeof(OutputParameter)));
            foreach(var propertyInfo in outputProperties) {
                var key = propertyInfo.Name;
                var attrs = propertyInfo.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is OutputParameter output && !string.IsNullOrWhiteSpace(output.Name))
                        key = output.Name;
                }
                if(propertyInfo.PropertyType == typeof(byte))
                    propertyInfo.SetValue(model, parameters.Get<byte>(key));
                else if(propertyInfo.PropertyType == typeof(byte?))
                    propertyInfo.SetValue(model, parameters.Get<byte?>(key));
                else if(propertyInfo.PropertyType == typeof(byte[]))
                    propertyInfo.SetValue(model, parameters.Get<byte[]>(key));
                else if(propertyInfo.PropertyType == typeof(sbyte))
                    propertyInfo.SetValue(model, parameters.Get<sbyte>(key));
                else if(propertyInfo.PropertyType == typeof(sbyte?))
                    propertyInfo.SetValue(model, parameters.Get<sbyte?>(key));
                else if(propertyInfo.PropertyType == typeof(short))
                    propertyInfo.SetValue(model, parameters.Get<short>(key));
                else if(propertyInfo.PropertyType == typeof(short?))
                    propertyInfo.SetValue(model, parameters.Get<short?>(key));
                else if(propertyInfo.PropertyType == typeof(ushort))
                    propertyInfo.SetValue(model, parameters.Get<ushort>(key));
                else if(propertyInfo.PropertyType == typeof(ushort?))
                    propertyInfo.SetValue(model, parameters.Get<ushort?>(key));
                else if(propertyInfo.PropertyType == typeof(int))
                    propertyInfo.SetValue(model, parameters.Get<int>(key));
                else if(propertyInfo.PropertyType == typeof(int?))
                    propertyInfo.SetValue(model, parameters.Get<int?>(key));
                else if(propertyInfo.PropertyType == typeof(uint))
                    propertyInfo.SetValue(model, parameters.Get<uint>(key));
                else if(propertyInfo.PropertyType == typeof(uint?))
                    propertyInfo.SetValue(model, parameters.Get<uint?>(key));
                else if(propertyInfo.PropertyType == typeof(long))
                    propertyInfo.SetValue(model, parameters.Get<long>(key));
                else if(propertyInfo.PropertyType == typeof(long?))
                    propertyInfo.SetValue(model, parameters.Get<long?>(key));
                else if(propertyInfo.PropertyType == typeof(ulong))
                    propertyInfo.SetValue(model, parameters.Get<ulong>(key));
                else if(propertyInfo.PropertyType == typeof(ulong?))
                    propertyInfo.SetValue(model, parameters.Get<ulong?>(key));
                else if(propertyInfo.PropertyType == typeof(float))
                    propertyInfo.SetValue(model, parameters.Get<float>(key));
                else if(propertyInfo.PropertyType == typeof(float?))
                    propertyInfo.SetValue(model, parameters.Get<float?>(key));
                else if(propertyInfo.PropertyType == typeof(double))
                    propertyInfo.SetValue(model, parameters.Get<double>(key));
                else if(propertyInfo.PropertyType == typeof(double?))
                    propertyInfo.SetValue(model, parameters.Get<double?>(key));
                else if(propertyInfo.PropertyType == typeof(decimal))
                    propertyInfo.SetValue(model, parameters.Get<decimal>(key));
                else if(propertyInfo.PropertyType == typeof(decimal?))
                    propertyInfo.SetValue(model, parameters.Get<decimal?>(key));
                else if(propertyInfo.PropertyType == typeof(bool))
                    propertyInfo.SetValue(model, parameters.Get<bool>(key));
                else if(propertyInfo.PropertyType == typeof(bool?))
                    propertyInfo.SetValue(model, parameters.Get<bool?>(key));
                else if(propertyInfo.PropertyType == typeof(string))
                    propertyInfo.SetValue(model, parameters.Get<string>(key));
                else if(propertyInfo.PropertyType == typeof(char))
                    propertyInfo.SetValue(model, parameters.Get<char>(key));
                else if(propertyInfo.PropertyType == typeof(char?))
                    propertyInfo.SetValue(model, parameters.Get<char?>(key));
                else if(propertyInfo.PropertyType == typeof(Guid))
                    propertyInfo.SetValue(model, parameters.Get<Guid>(key));
                else if(propertyInfo.PropertyType == typeof(Guid?))
                    propertyInfo.SetValue(model, parameters.Get<Guid?>(key));
                else if(propertyInfo.PropertyType == typeof(DateTime))
                    propertyInfo.SetValue(model, parameters.Get<DateTime>(key));
                else if(propertyInfo.PropertyType == typeof(DateTime?))
                    propertyInfo.SetValue(model, parameters.Get<DateTime?>(key));
                else if(propertyInfo.PropertyType == typeof(DateTimeOffset))
                    propertyInfo.SetValue(model, parameters.Get<DateTimeOffset>(key));
                else if(propertyInfo.PropertyType == typeof(DateTimeOffset?))
                    propertyInfo.SetValue(model, parameters.Get<DateTimeOffset?>(key));
            }
        }
        #endregion

        //Sync
        public void ExecuteReturnLess(string procedure) {
            _repository.Execute(procedure, commandType: CommandType.StoredProcedure);
        }
        public void ExecuteReturnLess(Schema model) {
            var parameters = MakeParameters(model);
            _repository.Execute(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
        }
        public IEnumerable<Result> Execute(string procedure) {
            return _repository.Query(procedure, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Result> Execute(Schema model) {
            var parameters = MakeParameters(model);
            var result = _repository.Query(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
            return result;
        }
        public Result ExecuteFirstOrDefault(string procedure) {
            return _repository.QueryFirstOrDefault(procedure, commandType: CommandType.StoredProcedure);
        }
        public Result ExecuteFirstOrDefault(Schema model) {
            var parameters = MakeParameters(model);
            var result = _repository.QueryFirstOrDefault(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
            return result;
        }

        //Async
        public async Task ExecuteReturnLessAsync(string procedure) {
            await _repository.ExecuteAsync(procedure, commandType: CommandType.StoredProcedure);
        }
        public async Task ExecuteReturnLessAsync(Schema model) {
            var parameters = MakeParameters(model);
            await _repository.ExecuteAsync(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
        }
        public async Task<IEnumerable<Result>> ExecuteAsync(string procedure) {
            return await _repository.QueryAsync(procedure, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Result>> ExecuteAsync(Schema model) {
            var parameters = MakeParameters(model);
            var result = await _repository.QueryAsync(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
            return result;
        }
        public async Task<Result> ExecuteFirstOrDefaultAsync(string procedure) {
            return await _repository.QueryFirstOrDefaultAsync(procedure, commandType: CommandType.StoredProcedure);
        }
        public async Task<Result> ExecuteFirstOrDefaultAsync(Schema model) {
            var parameters = MakeParameters(model);
            var result = await _repository.QueryFirstOrDefaultAsync(model.SchemaName(), parameters, commandType: CommandType.StoredProcedure);
            SetOutputValues(model, parameters);
            return result;
        }
    }
}