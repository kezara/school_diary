using school_diary.Utilities.Exceptions;
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
            else if (context.Exception is DepartmentNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Departmrents Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is MarksNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "No marks here"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is DepartmentNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Admin Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is TeacherDontTeachThisDepartment)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Admin Not Found"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is StudentDepartmentNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Student's not enrolled in this department"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is SubjectIsNotForThisGrade)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Subject is not for the selected grade"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is TeacherDontTeachThisSubjectException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Teacher does not teach this subject"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is SubjectNotFoundException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Subject Not Found"
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
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Bad Request"
                };
                throw new HttpResponseException(resp);
            }
            else if (context.Exception is SubjectExistsException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Student already learns this subject"
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