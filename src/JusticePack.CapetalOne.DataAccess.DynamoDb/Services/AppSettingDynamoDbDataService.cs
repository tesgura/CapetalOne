using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Options;
using JusticePack.CapetalOne.DataAccess.Core.Interfaces;
using JusticePack.CapetalOne.DataAccess.Core.Models;
using JusticePack.CapetalOne.Util.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JusticePack.CapetalOne.DataAccess.DynamoDb.Services
{
    public class AppSettingDynamoDbDataService : IAppSettingDataService
    {
        readonly IDynamoDBContext DDBContext;
        readonly IOptions<AWSSettingOptions> _awsSettingOptions;
        public AppSettingDynamoDbDataService(IOptions<AWSSettingOptions> awsSettingOptions)
        {
            _awsSettingOptions = awsSettingOptions;

            AWSConfigsDynamoDB.Context.TypeMappings[typeof(AppSetting)] = new Amazon.Util.TypeMapping(typeof(AppSetting), "JusticePackCapetalOneAppSetting");
            var dynamoDBContextConfig = new DynamoDBContextConfig
            {
                Conversion = DynamoDBEntryConversion.V2,
                TableNamePrefix = $"{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}_{Environment.GetEnvironmentVariable("ASPNETCORE_FEATURE")}_"
            };

            var amazonDynamoDBConfig = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(_awsSettingOptions.Value.Region)
            };

            this.DDBContext = new DynamoDBContext(new AmazonDynamoDBClient(_awsSettingOptions.Value.AccessKey, _awsSettingOptions.Value.SecretKey, amazonDynamoDBConfig), dynamoDBContextConfig);
        }

        public async Task Add(AppSetting entity)
        {
            await DDBContext.SaveAsync<AppSetting>(entity);
        }

        public async Task<List<AppSetting>> GetAll()
        {
            var search = this.DDBContext.ScanAsync<AppSetting>(null);
            var page = await search.GetNextSetAsync();

            return page;
        }

        public async Task<AppSetting> GetById(string id)
        {
            var appSetting = await DDBContext.LoadAsync<AppSetting>(id);
            return appSetting;
        }

        public Task SaveChanges()
        {
            return Task.CompletedTask;
        }

        public Task Update(AppSetting entity)
        {
            return Task.CompletedTask;
        }
    }
}
