using b = System.Action<B>;
using static System.Console;

/// <summary>
/// Represents the current state of a BF virtual machine
/// </summary>
public class B
{
	byte[] m = new byte[byte.MaxValue + nameof(m).Length];
	public byte p;
	public byte q { get { return m[p]; } set { m[p] = value; } }
}

/// <summary>
/// A fragment of a BF program.
/// </summary>
public class F
{
	b f;
	public F this[F g] => (F)(b => { for(f(b); -b.q != b.q; g.f(b)); });
	public static F _ = (F)(b => {});
	public static implicit operator F(b f) => new F { f = f };
	public static implicit operator B(F f) => f*new B();
	public static B operator*(F f, B b) { f.f(b); return b; }
	public static F operator|(F f, F g) => f.f + g.f;
	public static F operator%(F f, F g) => f|(F)(b => Write((char)b.q))|g;
	public static F operator/(F f, F g) => f|(F)(b => b.q = (byte)Read())|g;
	public static F operator!(F f) => (F)(b => b.p++)|f;
	public static F operator~(F f) => (F)(b => b.p--)|f;
	public static F operator+(F f) => (F)(b => b.q++)|f;
	public static F operator-(F f) => (F)(b => b.q--)|f;
}