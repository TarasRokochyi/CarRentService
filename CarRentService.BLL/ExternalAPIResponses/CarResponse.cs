﻿namespace CarRentService.BLL.ExternalAPIResponses
{
    public class CarResponse
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public List<CarData> Results { get; set; }
    }
}
