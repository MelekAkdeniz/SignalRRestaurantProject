namespace SignalRWebUI.Dto.RapidApiDtos
{
    //public class ResultTastyApi
    //{

    //    public class Rootobject
    //    {

    //        public Result[] results { get; set; }
    //    }

    //    public class Result
    //    {

    //        public string name { get; set; }

    //        public string original_video_url { get; set; }


    //        public string thumbnail_url { get; set; }

    //        public int total_time_minutes { get; set; }

    //    }
    //}
    public class ResultTastyApi
    {
        public List<Result> results { get; set; }
    }

    public class Result
    {
        public string name { get; set; }
        public string original_video_url { get; set; }
        public string thumbnail_url { get; set; }
        public int total_time_minutes { get; set; }
    }
}



    