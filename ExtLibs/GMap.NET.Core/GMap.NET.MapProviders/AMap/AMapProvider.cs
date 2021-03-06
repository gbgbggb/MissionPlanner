<<<<<<< HEAD
﻿

namespace GMap.NET.MapProviders
{
    using System;
    using GMap.NET.MapProviders;
    using GMap.NET.Projections;
    public abstract class AMapProviderBase : GMapProvider
    {
        public AMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://www.amap.com/";
            Copyright = string.Format("©{0} 高德 Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);    
        }

        public override PureProjection Projection
        {
            get { return AMapProjection.Instance; }
        }


        GMapProvider[] overlays;
=======
﻿namespace GMap.NET.MapProviders
{
    using GMap.NET;
    using GMap.NET.Projections;
    using System;

    public abstract class AMapProviderBase : GMapProvider
    {
        private GMapProvider[] overlays;

        public AMapProviderBase()
        {
            this.MaxZoom = null;
            base.RefererUrl = "http://www.amap.com/";
            base.Copyright = string.Format("©{0} 高德软件 Image© DigitalGlobe & chinasiwei | AIRBUS & EastDawn", DateTime.Today.Year);
        }

>>>>>>> diy/master
        public override GMapProvider[] Overlays
        {
            get
            {
<<<<<<< HEAD
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
    }

    public class AMapProvider : AMapProviderBase
    {
        public static readonly AMapProvider Instance;
   
        readonly Guid id = new Guid("EF3DD303-3F74-4938-BF40-232D0595EE88");
        public override Guid Id
        {
            get { return id; }
        }

        readonly string name = "高德地图";
        public override string Name
        {
            get
            {
                return name;
            }
        }

        static AMapProvider()
        {
            Instance = new AMapProvider();
        }

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = MakeTileImageUrl(pos, zoom, LanguageStr);

            return GetTileImageUsingHttp(url);
        }

        string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {

            //http://webrd04.is.autonavi.com/appmaptile?x=5&y=2&z=3&lang=zh_cn&size=1&scale=1&style=7
            string url = string.Format(UrlFormat, pos.X, pos.Y, zoom);
            Console.WriteLine("url:" + url);
            return url;
        }

        static readonly string UrlFormat = "http://webrd04.is.autonavi.com/appmaptile?x={0}&y={1}&z={2}&lang=zh_cn&size=1&scale=1&style=7";
    }
}
=======
                if (this.overlays == null)
                {
                    this.overlays = new GMapProvider[] { this };
                }
                return this.overlays;
            }
        }

        public override PureProjection Projection
        {
            get
            {
                return AMapProjection.Instance;
            }
        }
    }

    public class AMapProvider : AMapProviderBase
    {
        private readonly Guid id = new Guid("EF3DD303-3F74-4938-BF40-232D0595EE88");
        public static readonly AMapProvider Instance = new AMapProvider();
        private readonly string name = Resources.Strings.AMap;
        private static readonly string UrlFormat = "http://webrd04.is.autonavi.com/appmaptile?x={0}&y={1}&z={2}&lang=zh_cn&size=1&scale=1&style=7";

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = this.MakeTileImageUrl(pos, zoom, GMapProvider.LanguageStr);
            return base.GetTileImageUsingHttp(url);
        }

        private string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            string str = string.Format(UrlFormat, pos.X, pos.Y, zoom);
            Console.WriteLine("url:" + str);
            return str;
        }

        public override Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}

>>>>>>> diy/master
