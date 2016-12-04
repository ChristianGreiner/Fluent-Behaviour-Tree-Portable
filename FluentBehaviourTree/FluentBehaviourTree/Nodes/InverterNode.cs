﻿using System;

namespace FluentBehaviourTree
{
	/// <summary>
	/// Decorator node that inverts the success/failure of its child.
	/// </summary>
	public class InverterNode : IParentBehaviourTreeNode
	{
		/// <summary>
		/// Name of the node.
		/// </summary>
		private string name;

		/// <summary>
		/// The child to be inverted.
		/// </summary>
		private IBehaviourTreeNode childNode;

		public InverterNode(string name)
		{
			this.name = name;
		}

		public BehaviourTreeStatus Tick(TimeData time)
		{
			if (childNode == null)
			{
				throw new Exception("InverterNode must have a child node!");
			}

			var result = childNode.Tick(time);
			if (result == BehaviourTreeStatus.Failure)
			{
				return BehaviourTreeStatus.Success;
			}
			else if (result == BehaviourTreeStatus.Success)
			{
				return BehaviourTreeStatus.Failure;
			}
			else
			{
				return result;
			}
		}

		/// <summary>
		/// Add a child to the parent node.
		/// </summary>
		public void AddChild(IBehaviourTreeNode child)
		{
			if (this.childNode != null)
			{
				throw new Exception("Can't add more than a single child to InverterNode!");
			}

			this.childNode = child;
		}
	}
}