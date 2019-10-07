using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;

public sealed class AppLogger
{
    private readonly static object syncLock = new object();

    #region "Propiedades"
    private static NameValueCollection _Attribute = new NameValueCollection();
    public static NameValueCollection Attribute
    {
        get
        {
            return _Attribute;
        }
        set
        {
            _Attribute = value;
        }
    }

    #endregion

    /// <summary>
    /// Escribe el log de errores 
    /// </summary>
    /// <param name="pDescription"></param>
    /// <param name="ex"></param>

    public static void Iniciar()
    {
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener(@"C:\Users\JOHAN\Desktop\Proyecto Seguridad Pruebas Service\Servicio_Seguridad\Log.txt"));
        Trace.AutoFlush = true;
        Trace.WriteLine("Instancia iniciada");
    }

    public static void LogError<T>(string pDescription, Exception pEx, T pEntidad)
    {
        if (!(Trace.Listeners.Count > 0)) return;

        Monitor.Enter(syncLock);

        string serializer = ConvertToJson<T>(pEntidad);

        string strError = string.Concat(pEx.Message, "\n",
                                        pEx.Source, "\n",
                                        pEx.InnerException, "\n",
                                        pEx.StackTrace, "\n",
                                        "El objeto serializado es:", "\n",
                                        serializer);


        string Expression = @"C:\Users\JOHAN\Desktop\Proyecto Seguridad Pruebas Service\Servicio_Seguridad"/*AppSetting.GetAppLogExp()*/;
        Expression = Expression.Replace("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        Expression = Expression.Replace("Type", "ERROR");
        Expression = Expression.Replace("Thread", Thread.CurrentThread.ManagedThreadId.ToString());
        Expression = Expression.Replace("Message", strError);

        foreach (string key in Attribute.AllKeys)
        {
            Expression = Expression.Replace(key, Attribute[key]);
        }
        Trace.AutoFlush = true;
        Trace.WriteLine(Expression);

        Monitor.Exit(syncLock);
    }

    public static void LogError(string pDescription, Exception pEx)
    {
        if (!(Trace.Listeners.Count > 0)) return;

        Monitor.Enter(syncLock);

        string strError = string.Concat(pEx.Message, "\n",
                                        pEx.Source, "\n",
                                        pEx.InnerException, "\n",
                                        pEx.StackTrace);

        string Message = strError;
        string Expression = "Log.txt"/*AppSetting.GetAppLogExp()*/;
        Expression = Expression.Replace("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        Expression = Expression.Replace("Type", "ERROR");
        Expression = Expression.Replace("Thread", Thread.CurrentThread.ManagedThreadId.ToString());
        Expression = Expression.Replace("Message", strError);

        foreach (string key in Attribute.AllKeys)
        {
            Expression = Expression.Replace(key, Attribute[key]);
        }
        Trace.AutoFlush = true;
        Trace.WriteLine(Expression);

        Monitor.Exit(syncLock);
    }

    public static void LogInfo(string pDescription)
    {
        if (!(Trace.Listeners.Count > 0)) return;

        Monitor.Enter(syncLock);

        string Expression = "Log.txt"/*AppSetting.GetAppLogExp()*/;
        Expression = Expression.Replace("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
        Expression = Expression.Replace("Type", "INFO");
        Expression = Expression.Replace("Thread", Thread.CurrentThread.ManagedThreadId.ToString());
        Expression = Expression.Replace("Message", pDescription);

        foreach (string key in Attribute.AllKeys)
        {
            Expression = Expression.Replace(key, Attribute[key]);
        }

        Trace.AutoFlush = true;
        Trace.WriteLine(Expression);

        Monitor.Exit(syncLock);

    }

    private static string ConvertToJson<T>(T pObject)
    {
        DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(T));
        MemoryStream msObj = new MemoryStream();
        js.WriteObject(msObj, pObject);
        msObj.Position = 0;
        StreamReader sr = new StreamReader(msObj);
        string json = sr.ReadToEnd();

        sr.Close();
        msObj.Close();
        return json;
    }
}