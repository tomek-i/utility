/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class AddEdge : GraphTest
    {
        [Test]
        public void DuplicateEdge()
        {
            var graph = new Graph<int>(false);
            var random = new Random();

            var vertices = new List<Vertex<int>>();

            for (var i = 0; i < 100; i++)
            {
                vertices.Add(graph.AddVertex(i));
            }

            var edges = new List<Edge<int>>();

            for (var i = 0; i < 2000; i++)
            {
                var fromVertex = random.Next(100);
                var toVertex = random.Next(100);

                if (!graph.ContainsEdge(vertices[fromVertex], vertices[toVertex]))
                {
                    edges.Add(
                        graph.AddEdge(vertices[fromVertex], vertices[toVertex])
                        );
                }
            }

            foreach (var edge in edges)
            {
                Assert.IsTrue(graph.ContainsEdge(edge));
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex, edge.ToVertex));
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex.Data, edge.ToVertex.Data));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidEdgeDirected()
        {
            var graph = GetTestDirectedGraph();

            var vertices = graph.Vertices;

            var enumerator = vertices.GetEnumerator();

            enumerator.MoveNext();
            var vertex1 = enumerator.Current;

            enumerator.MoveNext();
            var vertex2 = enumerator.Current;

            var edge = new Edge<int>(vertex1, vertex2, false);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidEdgeUndirected()
        {
            var graph = GetTestUndirectedGraph();

            var vertices = graph.Vertices;

            var enumerator = vertices.GetEnumerator();

            enumerator.MoveNext();
            var vertex1 = enumerator.Current;

            enumerator.MoveNext();
            var vertex2 = enumerator.Current;

            var edge = new Edge<int>(vertex1, vertex2, true);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullToVertex()
        {
            var graph = new Graph<int>(true);
            graph.AddEdge(null, new Vertex<int>(3));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullFromVertex()
        {
            var graph = new Graph<int>(true);
            graph.AddEdge(new Vertex<int>(3), null);
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var counter = 0;

            for (var i = 0; i < 17; i += 2)
            {
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);

                counter++;

                Assert.AreEqual(graph.Edges.Count, counter);
                Assert.IsTrue(graph.ContainsEdge(edge));
                Assert.IsTrue(vertices[i].HasEmanatingEdgeTo(vertices[i + 2]));
                Assert.IsTrue(vertices[i].HasIncidentEdgeWith(vertices[i + 2]));

            }
        }

        [Test]
        public void VerticesAndWeightDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(4);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(6);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2, 10);
            graph.AddEdge(vertex1, vertex3, 12);
            graph.AddEdge(vertex2, vertex3, 14);

            Assert.AreEqual(graph.Edges.Count, 3);

            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex3));
            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex3));

            Assert.IsFalse(vertex2.HasEmanatingEdgeTo(vertex1));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex1));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2));
            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex3));
            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3));

            Assert.IsFalse(graph.ContainsEdge(vertex2, vertex1));
            Assert.IsFalse(graph.ContainsEdge(vertex3, vertex1));
            Assert.IsFalse(graph.ContainsEdge(vertex3, vertex2));
        }

        [Test]
        public void VerticesAndWeightUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(4);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(6);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2, 10);
            graph.AddEdge(vertex1, vertex3, 12);
            graph.AddEdge(vertex2, vertex3, 14);

            Assert.AreEqual(graph.Edges.Count, 3);

            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex3));
            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex3));

            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex1));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex1));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2));
            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex3));
            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3));

            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex1));
            Assert.IsTrue(graph.ContainsEdge(vertex3, vertex1));
            Assert.IsTrue(graph.ContainsEdge(vertex3, vertex2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullEdge()
        {
            var graph = new Graph<int>(false);
            graph.AddEdge(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionVertexNotInGraphUndirected()
        {
            var graph = GetTestUndirectedGraph();

            var edge = new Edge<int>(new Vertex<int>(1), new Vertex<int>(1), false);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionVertexNotInGraphDirected()
        {
            var graph = GetTestDirectedGraph();

            var edge = new Edge<int>(new Vertex<int>(1), new Vertex<int>(1), true);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcetionDuplicateEdgeUndirected1()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var edge = new Edge<int>(vertices[0], vertices[2], false);
            graph.AddEdge(edge);

            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDuplicateEdgeUndirected2()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var edge = new Edge<int>(vertices[0], vertices[2], false);
            graph.AddEdge(edge);

            graph.AddEdge(new Edge<int>(vertices[2], vertices[0], false));
        }
    }
}