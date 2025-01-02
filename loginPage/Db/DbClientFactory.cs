using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginPage.Db
{
    public class DbClientFactory
    {
        private string connectionStringSettings;
        private readonly ILogger<DbClientFactory> _logger;
        public DbClientFactory(IConfiguration configuration, ILogger<DbClientFactory> _logger)
        {
            this.connectionStringSettings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wpfDemo.db");
            this._logger = _logger;
        }

        public ISqlSugarClient GetSqlSugarClient()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.Sqlite,
                ConnectionString = $"DataSource={connectionStringSettings}",
                IsAutoCloseConnection = true,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    EntityService = (x, p) => //处理列名
                    {
                        //要排除DTO类，不然MergeTable会有问题
                        p.DbColumnName = UtilMethods.ToUnderLine(p.DbColumnName);//ToUnderLine驼峰转下划线方法
                    },
                    EntityNameService = (x, p) => //处理表名
                    {
                        //最好排除DTO类
                        p.DbTableName = UtilMethods.ToUnderLine(p.DbTableName);//ToUnderLine驼峰转下划线方法
                    }
                }
            });
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                StringBuilder sb = new();
                foreach (var parameter in pars)
                {
                    sb.Append($"{parameter.ParameterName} = {parameter.Value}");
                    sb.Append("\t");
                }
                _logger.LogInformation($"正在执行sql：{sql} \t，参数：{sb.ToString()}");

            };
            db.Aop.OnError = (exp) =>//SQL报错
            {
                _logger.LogError($"{exp.Message}");
            };
            return db;
        }

    }
}
