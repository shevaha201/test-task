using System.Collections.Generic;
using TestTask.WebApi.Core.Dto;

namespace TestTask.WebApi.Models
{
    public class GetRangeSettings
    {
        public class Request { }

        public class Response : List<Response.Item>
        {
            public Response(IEnumerable<Response.Item> items) : base(items) { }

            public class Item
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public int Value { get; set; }

                public static Item FromDto(GetRangeSettingsResult.Setting setting)
                {
                    return new Item
                    {
                        Id = setting.Id,
                        Name = setting.Name,
                        Value = setting.IntValue
                    };
                }
            }
        }
    }
}
