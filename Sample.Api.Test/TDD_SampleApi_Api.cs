using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace SampleApi.Api.Test
{
    [TestClass]
    public class TDD_SampleApi_Api
    {
        private string text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";

        [TestMethod]
        public void SetupApiSignature()
        {
            string text = "";
            string subtext = "";

            try
            {
                List<int> result = Tools.FindPosition(text, subtext);
            }
            catch (Exception) { }
        }

        [TestMethod]
        public void ParametersCannotBeNull_TextIsNullSoExceptionShouldBeThrown()
        {
            string text = null;
            string subtext = "";

            bool exceptionThrown = false;
            try
            {
                List<int> result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            exceptionThrown.ShouldBeTrue();
        }

        [TestMethod]
        public void ParametersCannotBeNull_SubTextIsNullSoExceptionShouldBeThrown()
        {
            string text = "";
            string subtext = null;

            var exceptionThrown = DoesThrowException(text, subtext);
            exceptionThrown.ShouldBeTrue();
        }

        private static bool DoesThrowException(string text, string subtext)
        {
            bool exceptionThrown = false;
            try
            {
                List<int> result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            return exceptionThrown;
        }

        [TestMethod]
        public void ParametersCannotBeNull_BothAreNullSoExceptionShouldBeThrown()
        {
            string text = null;
            string subtext = null;

            bool exceptionThrown = false;
            try
            {
                List<int> result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            exceptionThrown.ShouldBeTrue();
        }

        [TestMethod]
        public void ParametersCannotBeNull_NeitherAreNullSoNoExceptionShouldBeThrown()
        {
            string text = "";
            string subtext = "";

            bool exceptionThrown = false;
            try
            {
                List<int> result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            exceptionThrown.ShouldBeFalse();
        }

        [TestMethod]
        public void ReturnResultIsNotNullOnEmptyTest()
        {
            string text = "";
            string subtext = "";

            List<int> result = null;
            bool exceptionThrown = false;
            try
            {
                result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }

            exceptionThrown.ShouldBeFalse();
            result.ShouldNotBeNull();
            result.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void PrimaryTestOn_Polly_giving3FoundResultsInCorrectPosition()
        {
            string subtext = "Polly";

            List<int> result = Tools.FindPosition(text, subtext);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(3);
            result[0].ShouldEqual(1);
            result[1].ShouldEqual(26);
            result[2].ShouldEqual(51);
        }

        [TestMethod]
        public void PrimaryTestOn_polly_giving3FoundResultsInCorrectPosition()
        {
            string subtext = "polly";

            List<int> result = Tools.FindPosition(text, subtext);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(3);
            result[0].ShouldEqual(1);
            result[1].ShouldEqual(26);
            result[2].ShouldEqual(51);
        }

        [TestMethod]
        public void PrimaryTestOn_ll_giving5FoundResultsInCorrectPosition()
        {
            string subtext = "ll";

            List<int> result = Tools.FindPosition(text, subtext);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(5);
            result[0].ShouldEqual(3);
            result[1].ShouldEqual(28);
            result[2].ShouldEqual(53);
            result[3].ShouldEqual(78);
            result[4].ShouldEqual(82);
        }

        [TestMethod]
        public void PrimaryTestOn_Ll_giving5FoundResultsInCorrectPosition()
        {
            string subtext = "Ll";

            List<int> result = Tools.FindPosition(text, subtext);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(5);
            result[0].ShouldEqual(3);
            result[1].ShouldEqual(28);
            result[2].ShouldEqual(53);
            result[3].ShouldEqual(78);
            result[4].ShouldEqual(82);
        }

        [TestMethod]
        public void PrimaryTestOn_polly_giving2FoundResultsWhenCaseInsensitiveIsOff()
        {
            string subtext = "polly";

            List<int> result = Tools.FindPosition(text, subtext, false);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(2);
            result[0].ShouldEqual(26);
            result[1].ShouldEqual(51);
        }

        [TestMethod]
        public void PrimaryTestOn_Ll_giving0FoundResultsWhenCaseInsensitiveIsOff()
        {
            string subtext = "Ll";

            List<int> result = Tools.FindPosition(text, subtext, false);

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void PrimaryTestOn_X_giving0FoundResultsWithNoError()
        {
            string subtext = "X";

            List<int> result = null;
            bool exceptionThrown = false;
            try
            {
                result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            exceptionThrown.ShouldBeFalse();

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void PrimaryTestOn_polx_giving0FoundResultsWithNoError()
        {
            string subtext = "polx";

            List<int> result = null;
            bool exceptionThrown = false;
            try
            {
                result = Tools.FindPosition(text, subtext);
            }
            catch (NullReferenceException)
            {
                exceptionThrown = true;
            }
            exceptionThrown.ShouldBeFalse();

            result.ShouldNotBeNull();
            result.Count.ShouldEqual(0);
        }
    }
}
