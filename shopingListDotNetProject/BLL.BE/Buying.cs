using BLL.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Buying
    {
        Store store { get; set; }
        Product product { get; set; }
        int cost { get; set; }
        int pricePerOneProduct { get; set; }
        User user { get; set; }
    }
}
