using System;

namespace ST.Framework.DDD
{
	public abstract class ValueProper<T> : IEquatable<T> where T : ValueProper<T>
	{
		#region IEquatable<T> Members

		/// <summary>
		/// A hash function must have the following properties:
		/// - If two objects compare as equal, the GetHashCode method for each object must return the same value. 
		/// However, if two objects do not compare as equal, the GetHashCode methods for the two objects do not have to return different values.
		/// - The GetHashCode method for an object must consistently return the same hash code as long as there is no modification 
		/// to the object state that determines the return value of the object's Equals method. Note that this is true only for the 
		/// current execution of an application, and that a different hash code can be returned if the application is run again.
		/// - For the best performance, a hash function should generate an even distribution for all input, including input that is heavily clustered. 
		/// An implication is that small modifications to object state should result in large modifications to the resulting hash code for best hash table performance.
		/// - Hash functions should be inexpensive to compute.
		/// - The GetHashCode method should not throw exceptions. 
		/// 
		/// http://msdn.microsoft.com/en-us/library/system.object.gethashcode%28v=vs.110%29.aspx
		/// </summary>
		/// <returns></returns>
		public abstract override int GetHashCode();

		public abstract override string ToString();

		public abstract bool Equals(T other);

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			var item = obj as ValueProper<T>;

			return item != null && Equals((T)item);
		}

		public static bool operator ==(ValueProper<T> left, ValueProper<T> right)
		{
			return Equals(left, null) ? Equals(right, null) : left.Equals(right);
		}

		public static bool operator !=(ValueProper<T> left, ValueProper<T> right)
		{
			return !(left == right);
		}

		#endregion
	}
}