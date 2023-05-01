using Microsoft.AspNetCore.Mvc;

namespace LEGOINNOVATIVE.Model
{
    public class Plans
    {
        public string Type { get; set; }
        public int MinifigAmount { get; set; }
        public int BrickAmount { get; set; }
        public bool BrickMeFig { get; set; }
        public double Price { get; set; }
        public bool AllowPersonal { get; set; }

        public Plans(string type, int minifigAmount, int brickAmount, bool brickMeFig, double price, bool allowPersonal)
        {
            Type = type;
            MinifigAmount = minifigAmount;
            BrickAmount = brickAmount;
            BrickMeFig = brickMeFig;
            Price = price;
            AllowPersonal = allowPersonal;
        }
    }
}
