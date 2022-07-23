using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace AwsSDKIssue2077
{
    public class UnitTest1
    {
        [Fact]
        public async void TestEmptyString()
        {
            string json = """
            {
                "id": "test_demo",
                "data": [""]
            }
            """;

            var doc = Document.FromJson(json);

            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            await client.PutItemAsync(new()
            {
                TableName = "my_table",
                Item = doc.ToAttributeMap()
            });
        }
    }
}