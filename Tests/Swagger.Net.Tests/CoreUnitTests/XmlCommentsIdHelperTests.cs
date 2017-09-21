﻿using NUnit.Framework;
using Swagger.Net.Dummy.Controllers;
using Swagger.Net.XmlComments;

namespace Swagger.Net.Tests.CoreUnitTests
{
    [TestFixture]
    class XmlCommentsIdHelperTests
    {
        const string CTRLR = "M:Swagger.Net.Dummy.Controllers.";

        [Test]
        public void Method_from_inherited_action_post()
        {
            var methodInfo = typeof(BaseChildController).GetMethod("Post");
            var comment = methodInfo.GetCommentIdForMethod();
            Assert.AreEqual(CTRLR + "BaseController`1.Post(System.String)", comment);
        }

        [Test]
        public void Method_from_inherited_action_put()
        {
            var methodInfo = typeof(BaseChildController).GetMethod("Put");
            var comment = methodInfo.GetCommentIdForMethod();
            Assert.AreEqual(CTRLR + "BaseController`1.Put(`0,System.String)", comment);
        }

        [Test]
        public void Method_from_generic_action_post()
        {
            var methodInfo = typeof(BlobController).GetMethod("Post");
            var comment = methodInfo.GetCommentIdForMethod();
            Assert.AreEqual(CTRLR + "Blob`1.Post(System.Int32)", comment);
        }

        [Test]
        public void Method_from_generic_action_get()
        {
            var methodInfo = typeof(BlobController).GetMethod("Get");
            var comment = methodInfo.GetCommentIdForMethod();
            Assert.AreEqual(CTRLR + "Blob`1.Get(System.Nullable{System.Int32})", comment);
        }
    }
}
