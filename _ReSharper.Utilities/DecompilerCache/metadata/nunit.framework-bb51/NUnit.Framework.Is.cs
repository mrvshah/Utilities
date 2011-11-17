// Type: NUnit.Framework.Is
// Assembly: nunit.framework, Version=2.5.10.11092, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\MyData\git\Utilities\packages\NUnit.2.5.10.11092\lib\nunit.framework.dll

using NUnit.Framework.Constraints;
using System;
using System.Collections;

namespace NUnit.Framework
{
	public class Is
	{
		public static ConstraintExpression Not { get; }
		public static ConstraintExpression All { get; }
		public static NullConstraint Null { get; }
		public static TrueConstraint True { get; }
		public static FalseConstraint False { get; }
		public static NaNConstraint NaN { get; }
		public static EmptyConstraint Empty { get; }
		public static UniqueItemsConstraint Unique { get; }
		public static BinarySerializableConstraint BinarySerializable { get; }
		public static XmlSerializableConstraint XmlSerializable { get; }
		public static CollectionOrderedConstraint Ordered { get; }
		public static EqualConstraint EqualTo(object expected);
		public static SameAsConstraint SameAs(object expected);
		public static GreaterThanConstraint GreaterThan(object expected);
		public static GreaterThanOrEqualConstraint GreaterThanOrEqualTo(object expected);
		public static GreaterThanOrEqualConstraint AtLeast(object expected);
		public static LessThanConstraint LessThan(object expected);
		public static LessThanOrEqualConstraint LessThanOrEqualTo(object expected);
		public static LessThanOrEqualConstraint AtMost(object expected);
		public static ExactTypeConstraint TypeOf(Type expectedType);
		public static ExactTypeConstraint TypeOf<T>();
		public static InstanceOfTypeConstraint InstanceOf(Type expectedType);
		public static InstanceOfTypeConstraint InstanceOf<T>();

		[Obsolete("Use InstanceOf(expectedType)")]
		public static InstanceOfTypeConstraint InstanceOfType(Type expectedType);

		[Obsolete("Use InstanceOf<T>()")]
		public static InstanceOfTypeConstraint InstanceOfType<T>();

		public static AssignableFromConstraint AssignableFrom(Type expectedType);
		public static AssignableFromConstraint AssignableFrom<T>();
		public static AssignableToConstraint AssignableTo(Type expectedType);
		public static AssignableToConstraint AssignableTo<T>();
		public static CollectionEquivalentConstraint EquivalentTo(IEnumerable expected);
		public static CollectionSubsetConstraint SubsetOf(IEnumerable expected);
		public static SubstringConstraint StringContaining(string expected);
		public static StartsWithConstraint StringStarting(string expected);
		public static EndsWithConstraint StringEnding(string expected);
		public static RegexConstraint StringMatching(string pattern);
		public static SamePathConstraint SamePath(string expected);
		public static SubPathConstraint SubPath(string expected);
		public static SamePathOrUnderConstraint SamePathOrUnder(string expected);
		public static RangeConstraint InRange(IComparable from, IComparable to);
	}
}
