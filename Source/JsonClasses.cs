namespace JsonClasses {
    
    public class StandardResponse {
        public bool success;
        public string message;
        public string data;
    }

    // Json Files Internal Server

    public class DeviceIdsPacket {
        public List<string> authorised_device_ids;
    }

    public class TourData {
        public bool is_online;
        public string tour_details = string.Empty;
    }
}