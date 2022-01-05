using System;

namespace Entities.Dto
{
    public class FoodsDto
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Photo { get; set; }

        public Boolean State { get; set; } = true;
    }
}
