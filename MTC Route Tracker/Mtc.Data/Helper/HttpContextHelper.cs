using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MTC_Route_Tracker.Mtc.Data.Helper
{
    public class HttpContextHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current
        {
            get
            {
                if (_httpContextAccessor != null)
                    return _httpContextAccessor.HttpContext;
                else
                    return null;
            }
        }

        public static int? UserId
        {
            get
            {
                if (_httpContextAccessor != null)
                {
                    var userId = Current.User.FindFirst(ClaimType.UserId);
                    if (userId != null)
                    {
                        return int.Parse(userId.Value);
                    }
                    else
                        return null;

                }
                else
                    return null;
            }
        }

        public static string FullName
        {
            get
            {
                if (_httpContextAccessor != null)
                {
                    var fullName = Current.User.FindFirst(ClaimType.FullName);
                    if (fullName != null)
                    {
                        return fullName.Value;
                    }
                    else
                        return string.Empty;

                }
                else
                    return string.Empty;
            }
        }

        public static int? CustomerId
        {
            get
            {
                if (_httpContextAccessor != null)
                {
                    var customerId = Current.User.FindFirst(ClaimType.CustomerId);
                    if (customerId != null)
                    {
                        try
                        {
                            var custId = int.Parse(customerId.Value);
                            return custId;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                    else
                        return null;
                    ;
                }
                else
                    return null;
            }
        }
    }
}
