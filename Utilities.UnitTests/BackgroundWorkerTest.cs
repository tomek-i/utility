﻿using System;
using System.Threading;
using NUnit.Framework;
using TI.Utilities.Threading;

namespace TI.Utilities
{
    [TestFixture]
    public class BackgroundWorkerTest
    {
        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void ReportProgressNoReportingSupported()
        {
            var b = new BackgroundWorker<object, object, object>();
            Assert.IsFalse(b.IsBusy);
            Assert.Throws< InvalidOperationException>(() => b.ReportProgress(0));
            
        }

        [Test]
        public void ReportProgressNonBusy()
        {
            var b = new BackgroundWorker<object, object, object>
            {
                WorkerReportsProgress = true
            };
            Assert.IsFalse(b.IsBusy);
            b.ReportProgress(0);
        }
        [Test]
        public void DefaultValues()
        {
            var backgroundWorker = new BackgroundWorker<object, object, object>();
            Assert.IsTrue(backgroundWorker.ThrowExceptionOnCompleted);
            Assert.IsFalse(backgroundWorker.IsBusy);
            Assert.IsFalse(backgroundWorker.WorkerReportsProgress);
            Assert.IsFalse(backgroundWorker.WorkerSupportsCancellation);
        }

        [Test]
        [Ignore("not sure why to ignore")]
        public void ThrowExceptionOnCompletedTrue()
        {
            var b = new BackgroundWorker<object, object, object>
            {
                ThrowExceptionOnCompleted = true,
                DoWork = ThrowException
            };

            b.RunWorkerAsync();
        }

        [Test]
        public void ThrowExceptionOnCompletedFalse()
        {
            var b = new BackgroundWorker<object, object, object>
            {
                ThrowExceptionOnCompleted = false,
                DoWork = ThrowException
            };
            b.RunWorkerAsync();
        }

        private static void ThrowException(object arg1, DoWorkEventArgs<object, object> arg2)
        {
            throw new Exception();
        }

        [TestFixture]
        public class ExecuteOnCallingThread
        {
            BackgroundWorker<object, object, object> backgroundWorker;
            readonly int callingThreadId = Thread.CurrentThread.ManagedThreadId;

            [Test]
            public void Run()
            {
                backgroundWorker = new BackgroundWorker<object, object, object>
                {
                    DoWork = DoWork
                };
                backgroundWorker.SleepWhileBusy();

            }

            private void DoWork(object sender, DoWorkEventArgs<object, object> eventArgs)
            {
                Assert.AreNotEqual(Thread.CurrentThread.ManagedThreadId, callingThreadId);
                backgroundWorker.ExecuteOnCallingThread<object>(Foo2, null);
            }

            private void Foo2(object obj)
            {
                Assert.AreEqual(Thread.CurrentThread.ManagedThreadId, callingThreadId);
            }
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void CancelAsyncNoCancellationSupported()
        {
            var backgroundWorker = new BackgroundWorker<object, object, object>();
            Assert.IsFalse(backgroundWorker.IsBusy);
            Assert.Throws<InvalidOperationException>(() => backgroundWorker.CancelAsync());
            
        }

        [Test]
        public void CancelAsyncNonBusy()
        {
            var backgroundWorker = new BackgroundWorker<object, object, object>
            {
                WorkerSupportsCancellation = true
            };
            Assert.IsFalse(backgroundWorker.IsBusy);
            backgroundWorker.CancelAsync();
        }


        [TestFixture]
        public class TestProgress
        {
            private int progressChangeCount;

            readonly BackgroundWorker<object, object, object> backgroundWorker = new BackgroundWorker<object, object, object>();
            private bool doworkCalled;

            public TestProgress()
            {

                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork = DoWork;
                backgroundWorker.ProgressChanged = ProgressChanged;
            }


            private void DoWork(object sender, DoWorkEventArgs<object, object> eventArgs)
            {
                doworkCalled = true;
                for (var i = 0; i < 100; i++)
                {
                    Thread.Sleep(5);
                    backgroundWorker.ReportProgress(i / 10);
                }
            }

            [Test]
            public void Start()
            {
                backgroundWorker.RunWorkerAsync();
                while (backgroundWorker.IsBusy)
                {
                    Thread.Sleep(10);
                }
                Assert.AreEqual(100, progressChangeCount);
                Assert.IsTrue(doworkCalled);
            }

            private void ProgressChanged(object sender, ProgressChangedEventArgs<object> eventArgs)
            {
                Interlocked.Increment(ref progressChangeCount);
            }
        }
    }
}