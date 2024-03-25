using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyBGList.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string DeliveryPlace { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<PacketDTO> Packets { get; set; }
        public List<OrderBakingGoodDTO> OrderBakingGood { get; set; }
    }

    public class PacketDTO
    {
        public int PacketId { get; set; }
        public string TrackId { get; set; }
    }

    public class OrderBakingGoodDTO
    {
        //public int OrderId { get; set; }
        public int BakingGoodId { get; set; }
        public int Quantity { get; set; }
        public BakingGoodDTO BakingGood { get; set; }
    }

    public class BakingGoodDTO
    {
        public int BakingGoodId { get; set; }
        public string BgName { get; set; }
        public DateTime DateProduced { get; set; }
    }

    public class RestDTO<T>
    {
        public List<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public List<LinkDTO> Links { get; set; }
    }

    public class LinkDTO
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public LinkDTO(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }

    public class RequestDTO<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string FilterQuery { get; set; }
    }
}

