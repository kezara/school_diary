﻿using school_diary.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace school_diary.Filters
{
    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is UserNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "User Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is AdminNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Admin Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is ParentNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Parent Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is StudentNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Student Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is TeacherNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Teacher Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is BadRequestException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Bad Request"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is Exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Something went wrong, please contact support@email.com"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}