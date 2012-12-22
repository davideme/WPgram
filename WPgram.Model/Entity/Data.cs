using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IWPgram.Model.Entity
{

    [DataContract]
    public partial class MetaClass
    {

        [DataMember]
        public int code;
    }

    [DataContract]
    public partial class FeedClass
    {

        [DataMember]
        public object pagination;

        [DataMember]
        public MetaClass meta;

        [DataMember]
        public FeedDataClass[] data;
    }

    [DataContract]
    public partial class LocationClass
    {

        [DataMember]
        public string id;

        [DataMember]
        public double latitude;

        [DataMember]
        public double longitude;

        [DataMember]
        public string name;
    }

    [DataContract]
    public partial class CommentsClass
    {

        [DataMember]
        public int count;

        [DataMember]
        public UserDataClass[] data;
    }

    [DataContract]
    public partial class UserDataClass
    {

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string full_name;

        [DataMember]
        public string id;

        [DataMember]
        public string profile_picture { get; set; }
    }

    [DataContract]
    public partial class Low_resolutionClass
    {

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public int width;

        [DataMember]
        public int height;
    }

    [DataContract]
    public partial class ImagesClass
    {

        [DataMember]
        public Low_resolutionClass low_resolution;

        [DataMember]
        public Low_resolutionClass thumbnail;

        [DataMember]
        public Low_resolutionClass standard_resolution { get; set; }
    }

    [DataContract]
    public partial class FeedDataClass
    {

        [DataMember]
        public LocationClass location;

        [DataMember]
        public CommentsClass comments;

        [DataMember]
        public object caption;

        [DataMember]
        public string link;

        [DataMember]
        public CommentsClass likes;

        private string _created_time;
        [DataMember]
        public string created_time 
        { 
            get { return this._created_time;  }
            set 
            { 
                _created_time = value;
                createdTimeSpan = DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0,0).AddSeconds(Convert.ToDouble(created_time)).ToLocalTime());
            } 
        }

        public TimeSpan createdTimeSpan { get; private set; }

        [DataMember]
        public ImagesClass images { get; set; }

        [DataMember]
        public string type;

        [DataMember]
        public string filter;

        [DataMember]
        public object[] tags;

        [DataMember]
        public string id;

        [DataMember]
        public UserDataClass user { get; set; }
    }
}
