using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Highest priority item (C:10) is at the end of the queue.
    // Expected Result: C should be returned.
    // Defect(s) Found:
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("C", result); 
    }

    [TestMethod]
    // Scenario: Add two items with the same priority and a third item with a lower priority at the end (A:3, B:3, C:1).
    // Expected Result: A should come out first (FIFO).
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }
}