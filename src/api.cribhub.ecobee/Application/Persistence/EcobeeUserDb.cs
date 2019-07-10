using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using api.cribhub.ecobee.domain.Features;
using api.cribhub.ecobee.domain.Model;
using clearwaterstream.AWS.Db;
using clearwaterstream.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace api.cribhub.ecobee.Application.Persistence
{
    public class EcobeeUserDb : IEcobeeUserPersistor, IDisposable
    {
        static AmazonDynamoDBClient dbClient;

        static readonly Lazy<AmazonDynamoDBClient> dbClientFactory = new Lazy<AmazonDynamoDBClient>(() =>
        {
            dbClient = DynamoDBClientFactory.CreateClient();

            return dbClient;
        });

        static readonly Lazy<Table> UsersTable = new Lazy<Table>(() =>
        {
            var result = Table.LoadTable(dbClientFactory.Value, "ecobee-user");

            return result;
        });

        public async Task Add(EcobeeUserAuthInfo userAuthInfo, CancellationToken cancellationToken)
        {
            userAuthInfo.lastUpdatedOn = DateTime.UtcNow;

            var json = JsonConvert.SerializeObject(userAuthInfo, JsonUtil.LeanSerializerSettings);

            var record = Document.FromJson(json);

            await UsersTable.Value.PutItemAsync(record, cancellationToken);
        }

        public void Dispose()
        {
            dbClient?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
