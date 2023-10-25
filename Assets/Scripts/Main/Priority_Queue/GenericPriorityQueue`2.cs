﻿// Decompiled with JetBrains decompiler
// Type: Priority_Queue.GenericPriorityQueue`2
// Assembly: Main, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89B9E799-8342-47B3-85ED-672D6883482A
// Assembly location: C:\Program Files\Oculus\Software\Software\hyperbolic-magnetism-beat-saber\Beat Saber_Data\Managed\Main.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace Priority_Queue
{
  public class GenericPriorityQueue<TItem, TPriority> : 
    IFixedSizePriorityQueue<TItem, TPriority>,
    IPriorityQueue<TItem, TPriority>,
    IEnumerable<TItem>,
    IEnumerable
    where TItem : GenericPriorityQueueNode<TPriority>
    where TPriority : IComparable<TPriority>
  {
    protected int _numNodes;
    protected TItem[] _nodes;
    protected long _numNodesEverEnqueued;
    protected readonly Comparison<TPriority> _comparer;

    public GenericPriorityQueue(int maxNodes)
      : this(maxNodes, (IComparer<TPriority>) Comparer<TPriority>.Default)
    {
    }

    public GenericPriorityQueue(int maxNodes, IComparer<TPriority> comparer)
      : this(maxNodes, new Comparison<TPriority>(comparer.Compare))
    {
    }

    public GenericPriorityQueue(int maxNodes, Comparison<TPriority> comparer)
    {
      this._numNodes = 0;
      this._nodes = new TItem[maxNodes + 1];
      this._numNodesEverEnqueued = 0L;
      this._comparer = comparer;
    }

    public int Count => this._numNodes;

    public int MaxSize => this._nodes.Length - 1;

    public virtual void Clear()
    {
      Array.Clear((Array) this._nodes, 1, this._numNodes);
      this._numNodes = 0;
    }

    public virtual bool Contains(TItem node) => (object) this._nodes[node.QueueIndex] == (object) node;

    public virtual void Enqueue(TItem node, TPriority priority)
    {
      node.Priority = priority;
      ++this._numNodes;
      this._nodes[this._numNodes] = node;
      node.QueueIndex = this._numNodes;
      node.InsertionIndex = this._numNodesEverEnqueued++;
      this.CascadeUp(node);
    }

    public virtual void CascadeUp(TItem node)
    {
      if (node.QueueIndex <= 1)
        return;
      int index = node.QueueIndex >> 1;
      TItem node1 = this._nodes[index];
      if (this.HasHigherPriority(node1, node))
        return;
      this._nodes[node.QueueIndex] = node1;
      node1.QueueIndex = node.QueueIndex;
      node.QueueIndex = index;
      while (index > 1)
      {
        index >>= 1;
        TItem node2 = this._nodes[index];
        if (!this.HasHigherPriority(node2, node))
        {
          this._nodes[node.QueueIndex] = node2;
          node2.QueueIndex = node.QueueIndex;
          node.QueueIndex = index;
        }
        else
          break;
      }
      this._nodes[node.QueueIndex] = node;
    }

    public virtual void CascadeDown(TItem node)
    {
      int queueIndex = node.QueueIndex;
      int index1 = 2 * queueIndex;
      if (index1 > this._numNodes)
        return;
      int index2 = index1 + 1;
      TItem node1 = this._nodes[index1];
      int index3;
      if (this.HasHigherPriority(node1, node))
      {
        if (index2 > this._numNodes)
        {
          node.QueueIndex = index1;
          node1.QueueIndex = queueIndex;
          this._nodes[queueIndex] = node1;
          this._nodes[index1] = node;
          return;
        }
        TItem node2 = this._nodes[index2];
        if (this.HasHigherPriority(node1, node2))
        {
          node1.QueueIndex = queueIndex;
          this._nodes[queueIndex] = node1;
          index3 = index1;
        }
        else
        {
          node2.QueueIndex = queueIndex;
          this._nodes[queueIndex] = node2;
          index3 = index2;
        }
      }
      else
      {
        if (index2 > this._numNodes)
          return;
        TItem node3 = this._nodes[index2];
        if (!this.HasHigherPriority(node3, node))
          return;
        node3.QueueIndex = queueIndex;
        this._nodes[queueIndex] = node3;
        index3 = index2;
      }
      int index4;
      TItem node4;
      while (true)
      {
        index4 = 2 * index3;
        if (index4 <= this._numNodes)
        {
          int index5 = index4 + 1;
          node4 = this._nodes[index4];
          if (this.HasHigherPriority(node4, node))
          {
            if (index5 <= this._numNodes)
            {
              TItem node5 = this._nodes[index5];
              if (this.HasHigherPriority(node4, node5))
              {
                node4.QueueIndex = index3;
                this._nodes[index3] = node4;
                index3 = index4;
              }
              else
              {
                node5.QueueIndex = index3;
                this._nodes[index3] = node5;
                index3 = index5;
              }
            }
            else
              goto label_16;
          }
          else if (index5 <= this._numNodes)
          {
            TItem node6 = this._nodes[index5];
            if (this.HasHigherPriority(node6, node))
            {
              node6.QueueIndex = index3;
              this._nodes[index3] = node6;
              index3 = index5;
            }
            else
              goto label_24;
          }
          else
            goto label_21;
        }
        else
          break;
      }
      node.QueueIndex = index3;
      this._nodes[index3] = node;
      return;
label_16:
      node.QueueIndex = index4;
      node4.QueueIndex = index3;
      this._nodes[index3] = node4;
      this._nodes[index4] = node;
      return;
label_21:
      node.QueueIndex = index3;
      this._nodes[index3] = node;
      return;
label_24:
      node.QueueIndex = index3;
      this._nodes[index3] = node;
    }

    public virtual bool HasHigherPriority(TItem higher, TItem lower)
    {
      int num = this._comparer(higher.Priority, lower.Priority);
      if (num < 0)
        return true;
      return num == 0 && higher.InsertionIndex < lower.InsertionIndex;
    }

    public virtual TItem Dequeue()
    {
      TItem node1 = this._nodes[1];
      if (this._numNodes == 1)
      {
        this._nodes[1] = default (TItem);
        this._numNodes = 0;
        return node1;
      }
      TItem node2 = this._nodes[this._numNodes];
      this._nodes[1] = node2;
      node2.QueueIndex = 1;
      this._nodes[this._numNodes] = default (TItem);
      --this._numNodes;
      this.CascadeDown(node2);
      return node1;
    }

    public virtual void Resize(int maxNodes)
    {
      TItem[] destinationArray = new TItem[maxNodes + 1];
      int num = Math.Min(maxNodes, this._numNodes);
      Array.Copy((Array) this._nodes, (Array) destinationArray, num + 1);
      this._nodes = destinationArray;
    }

    public TItem First => this._nodes[1];

    public virtual void UpdatePriority(TItem node, TPriority priority)
    {
      node.Priority = priority;
      this.OnNodeUpdated(node);
    }

    public virtual void OnNodeUpdated(TItem node)
    {
      int index = node.QueueIndex >> 1;
      if (index > 0 && this.HasHigherPriority(node, this._nodes[index]))
        this.CascadeUp(node);
      else
        this.CascadeDown(node);
    }

    public virtual void Remove(TItem node)
    {
      if (node.QueueIndex == this._numNodes)
      {
        this._nodes[this._numNodes] = default (TItem);
        --this._numNodes;
      }
      else
      {
        TItem node1 = this._nodes[this._numNodes];
        this._nodes[node.QueueIndex] = node1;
        node1.QueueIndex = node.QueueIndex;
        this._nodes[this._numNodes] = default (TItem);
        --this._numNodes;
        this.OnNodeUpdated(node1);
      }
    }

    public virtual void ResetNode(TItem node) => node.QueueIndex = 0;

    public virtual IEnumerator<TItem> GetEnumerator()
    {
      for (int i = 1; i <= this._numNodes; ++i)
        yield return this._nodes[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public virtual bool IsValidQueue()
    {
      for (int index1 = 1; index1 < this._nodes.Length; ++index1)
      {
        if ((object) this._nodes[index1] != null)
        {
          int index2 = 2 * index1;
          if (index2 < this._nodes.Length && (object) this._nodes[index2] != null && this.HasHigherPriority(this._nodes[index2], this._nodes[index1]))
            return false;
          int index3 = index2 + 1;
          if (index3 < this._nodes.Length && (object) this._nodes[index3] != null && this.HasHigherPriority(this._nodes[index3], this._nodes[index1]))
            return false;
        }
      }
      return true;
    }
  }
}
