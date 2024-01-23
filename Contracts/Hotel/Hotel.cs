using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UME.Booking.SharedBookings.Contracts
{

    public class SearchWidget
    {
        public string Destination { get; set; }

        public RoomGroup Roomgroup { get; set; }
        public MoreRoomOption MoreRoomOptions { get; set; }

    }

    public class Filter{
        public string hotelname { get; set; }
    }

    public class RoomGroup
    {
        public string NoOfRooms { get; set; }
        public string AdultsPerRoom { get; set; }

    }
    public class MoreRoomOption
    {
        public string Children { get; set; }
        public string Adult { get; set; }

    }

}
