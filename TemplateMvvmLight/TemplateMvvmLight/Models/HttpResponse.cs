using System;
using System.Collections.Generic;
using System.Text;
using TemplateMvvmLight.Constants;

namespace TemplateMvvmLight.Models
{
    /// <summary>
    /// Risposta restituita da una chiamata http
    /// </summary>
    public class HttpResponse<T>
    {
        public ErrorResponse? Error { get; set; }
        public T Result { get; set; }
    }
}
