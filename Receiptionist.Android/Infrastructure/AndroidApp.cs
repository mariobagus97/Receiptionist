using System;
using Android.App;
using Android.Runtime;
using Intersoft.Crosslight.Android;

namespace Receiptionist.Android.Infrastructure
{
    /// <summary>
    ///     Class that manages the entire Android Application lifecycle.
    ///     Useful for intercepting global events.
    /// </summary>
    /// <seealso cref="Intersoft.Crosslight.Android.AndroidApplication" />
    [Application]
    public class AndroidApp : AndroidApplication
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AndroidApp" /> class.
        /// </summary>
        /// <param name="intPtr">The int PTR.</param>
        /// <param name="jniHandleOwnership">The jni handle ownership.</param>
        public AndroidApp(IntPtr intPtr, JniHandleOwnership jniHandleOwnership)
            : base(intPtr, jniHandleOwnership)
        {
        }

        #endregion
    }
}