﻿using Dapper;
using shared.utility._app;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;

namespace shared.utility.infrastructure {
    public interface IParameterHandler {
        DynamicParameters MakeParameters<T>(T schema);
        void SetOutputValues<T>(T model, DynamicParameters parameters);
        void SetReturnValue<T>(T model, DynamicParameters parameters);
    }
    public interface IParameterHandler<T> {
        DynamicParameters MakeParameters();
        void SetOutputValues(DynamicParameters parameters);
        void SetReturnValue(DynamicParameters parameters);
    }
    public class ParameterHandler: IParameterHandler {
        public DynamicParameters MakeParameters<T>(T schema) {
            var parameters = new DynamicParameters();
            // Input parameters (Include IEnumerable as Table type value)
            var inputProperties = schema.GetType().GetProperties().Where(attr => Attribute.IsDefined(attr, typeof(InputParameter)));
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
            // Output parameters
            var outputProperties = schema.GetType().GetProperties()?.Where(attr => Attribute.IsDefined(attr, typeof(OutputParameter)));
            foreach(var item in outputProperties) {
                var key = item.Name;
                var attrs = item.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is OutputParameter output && !string.IsNullOrWhiteSpace(output.Name))
                        key = output.Name;
                }
                parameters.Add(key, dbType: item.PropertyType.ToDbType(), direction: ParameterDirection.Output);
            }
            // Return parameter
            var returnPropery = schema.GetType().GetProperties().FirstOrDefault(attr => Attribute.IsDefined(attr, typeof(ReturnParameter)));
            if(returnPropery != null) {
                parameters.Add(returnPropery.Name, dbType: returnPropery.PropertyType.ToDbType(), direction: ParameterDirection.ReturnValue);
            }
            return parameters;
        }
        public void SetOutputValues<T>(T model, DynamicParameters parameters) {
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
        public void SetReturnValue<T>(T model, DynamicParameters parameters) {
            var returnProperty = model.GetType().GetProperties().FirstOrDefault(item => Attribute.IsDefined(item, typeof(ReturnParameter)));
            if(returnProperty != null) {
                returnProperty.SetValue(model, parameters.Get<int>(returnProperty.Name));
            }
        }
    }
    public class ParameterHandler<T>: IParameterHandler<T> {
        #region Constructor
        private readonly Type _type;
        public ParameterHandler() {
            _type = typeof(T);
        }
        #endregion
        public DynamicParameters MakeParameters() {
            var parameters = new DynamicParameters();
            // Input parameters (Include IEnumerable as Table type value)
            var inputProperties = _type.GetProperties().Where(attr => Attribute.IsDefined(attr, typeof(InputParameter)));
            foreach(var item in inputProperties) {
                var key = item.Name;
                var value = item.GetValue(_type, null);
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
                        if(attr is TableAttribute table && !string.IsNullOrWhiteSpace(table.Name))
                            genericTypeName = table.Name;
                    }
                    var dataTable = new DataTable(genericTypeName);
                    foreach(var column in genericType.GetProperties())
                        dataTable.Columns.Add(column.Name);
                    var list = (System.Collections.IEnumerable)item.GetValue(_type);
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
            // Output parameters
            var outputProperties = _type.GetProperties()?.Where(attr => Attribute.IsDefined(attr, typeof(OutputParameter)));
            foreach(var item in outputProperties) {
                var key = item.Name;
                var attrs = item.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is OutputParameter output && !string.IsNullOrWhiteSpace(output.Name))
                        key = output.Name;
                }
                parameters.Add(key, dbType: item.PropertyType.ToDbType(), direction: ParameterDirection.Output);
            }
            // Return parameter
            var returnPropery = _type.GetProperties().FirstOrDefault(attr => Attribute.IsDefined(attr, typeof(ReturnParameter)));
            if(returnPropery != null) {
                parameters.Add(returnPropery.Name, dbType: returnPropery.PropertyType.ToDbType(), direction: ParameterDirection.ReturnValue);
            }
            return parameters;
        }
        public void SetOutputValues(DynamicParameters parameters) {
            var outputProperties = _type.GetType().GetProperties().Where(item => Attribute.IsDefined(item, typeof(OutputParameter)));
            foreach(var propertyInfo in outputProperties) {
                var key = propertyInfo.Name;
                var attrs = propertyInfo.GetCustomAttributes(true);
                foreach(var attr in attrs) {
                    if(attr is OutputParameter output && !string.IsNullOrWhiteSpace(output.Name))
                        key = output.Name;
                }
                if(propertyInfo.PropertyType == typeof(byte))
                    propertyInfo.SetValue(_type, parameters.Get<byte>(key));
                else if(propertyInfo.PropertyType == typeof(byte?))
                    propertyInfo.SetValue(_type, parameters.Get<byte?>(key));
                else if(propertyInfo.PropertyType == typeof(byte[]))
                    propertyInfo.SetValue(_type, parameters.Get<byte[]>(key));
                else if(propertyInfo.PropertyType == typeof(sbyte))
                    propertyInfo.SetValue(_type, parameters.Get<sbyte>(key));
                else if(propertyInfo.PropertyType == typeof(sbyte?))
                    propertyInfo.SetValue(_type, parameters.Get<sbyte?>(key));
                else if(propertyInfo.PropertyType == typeof(short))
                    propertyInfo.SetValue(_type, parameters.Get<short>(key));
                else if(propertyInfo.PropertyType == typeof(short?))
                    propertyInfo.SetValue(_type, parameters.Get<short?>(key));
                else if(propertyInfo.PropertyType == typeof(ushort))
                    propertyInfo.SetValue(_type, parameters.Get<ushort>(key));
                else if(propertyInfo.PropertyType == typeof(ushort?))
                    propertyInfo.SetValue(_type, parameters.Get<ushort?>(key));
                else if(propertyInfo.PropertyType == typeof(int))
                    propertyInfo.SetValue(_type, parameters.Get<int>(key));
                else if(propertyInfo.PropertyType == typeof(int?))
                    propertyInfo.SetValue(_type, parameters.Get<int?>(key));
                else if(propertyInfo.PropertyType == typeof(uint))
                    propertyInfo.SetValue(_type, parameters.Get<uint>(key));
                else if(propertyInfo.PropertyType == typeof(uint?))
                    propertyInfo.SetValue(_type, parameters.Get<uint?>(key));
                else if(propertyInfo.PropertyType == typeof(long))
                    propertyInfo.SetValue(_type, parameters.Get<long>(key));
                else if(propertyInfo.PropertyType == typeof(long?))
                    propertyInfo.SetValue(_type, parameters.Get<long?>(key));
                else if(propertyInfo.PropertyType == typeof(ulong))
                    propertyInfo.SetValue(_type, parameters.Get<ulong>(key));
                else if(propertyInfo.PropertyType == typeof(ulong?))
                    propertyInfo.SetValue(_type, parameters.Get<ulong?>(key));
                else if(propertyInfo.PropertyType == typeof(float))
                    propertyInfo.SetValue(_type, parameters.Get<float>(key));
                else if(propertyInfo.PropertyType == typeof(float?))
                    propertyInfo.SetValue(_type, parameters.Get<float?>(key));
                else if(propertyInfo.PropertyType == typeof(double))
                    propertyInfo.SetValue(_type, parameters.Get<double>(key));
                else if(propertyInfo.PropertyType == typeof(double?))
                    propertyInfo.SetValue(_type, parameters.Get<double?>(key));
                else if(propertyInfo.PropertyType == typeof(decimal))
                    propertyInfo.SetValue(_type, parameters.Get<decimal>(key));
                else if(propertyInfo.PropertyType == typeof(decimal?))
                    propertyInfo.SetValue(_type, parameters.Get<decimal?>(key));
                else if(propertyInfo.PropertyType == typeof(bool))
                    propertyInfo.SetValue(_type, parameters.Get<bool>(key));
                else if(propertyInfo.PropertyType == typeof(bool?))
                    propertyInfo.SetValue(_type, parameters.Get<bool?>(key));
                else if(propertyInfo.PropertyType == typeof(string))
                    propertyInfo.SetValue(_type, parameters.Get<string>(key));
                else if(propertyInfo.PropertyType == typeof(char))
                    propertyInfo.SetValue(_type, parameters.Get<char>(key));
                else if(propertyInfo.PropertyType == typeof(char?))
                    propertyInfo.SetValue(_type, parameters.Get<char?>(key));
                else if(propertyInfo.PropertyType == typeof(Guid))
                    propertyInfo.SetValue(_type, parameters.Get<Guid>(key));
                else if(propertyInfo.PropertyType == typeof(Guid?))
                    propertyInfo.SetValue(_type, parameters.Get<Guid?>(key));
                else if(propertyInfo.PropertyType == typeof(DateTime))
                    propertyInfo.SetValue(_type, parameters.Get<DateTime>(key));
                else if(propertyInfo.PropertyType == typeof(DateTime?))
                    propertyInfo.SetValue(_type, parameters.Get<DateTime?>(key));
                else if(propertyInfo.PropertyType == typeof(DateTimeOffset))
                    propertyInfo.SetValue(_type, parameters.Get<DateTimeOffset>(key));
                else if(propertyInfo.PropertyType == typeof(DateTimeOffset?))
                    propertyInfo.SetValue(_type, parameters.Get<DateTimeOffset?>(key));
            }
        }
        public void SetReturnValue(DynamicParameters parameters) {
            var returnProperty = _type.GetType().GetProperties().FirstOrDefault(item => Attribute.IsDefined(item, typeof(ReturnParameter)));
            if(returnProperty != null) {
                returnProperty.SetValue(_type, parameters.Get<int>(returnProperty.Name));
            }
        }
    }
}
