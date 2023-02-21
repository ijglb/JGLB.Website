using JGLB.Website.Data;
using Microsoft.JSInterop;

namespace JGLB.Website
{
    public class AppEx
    {
        public static string Title(string title) => $"{title} - 极光萝卜";

        public static event EventHandler<Window> OnWindowResize;
        [JSInvokableAttribute()]
        public static async Task WindowResize(decimal innerWidth, decimal innerHeight)
        {
            if (OnWindowResize != null) 
            {
                await Task.Run(() =>
                {
                    OnWindowResize(null, new Window { InnerWidth = innerWidth, InnerHeight = innerHeight });
                });
            }
        }
    }
}
