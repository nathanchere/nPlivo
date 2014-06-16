namespace nPlivo
{
    public class SmsMessageRequest
    {
        public string PhoneNumberFrom { get; set; }
        public string PhoneNumberTo { get; set; }
        public string Body { get; set; }

        // TODO: callback details
    }
}