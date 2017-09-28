# Brainfcsk

A [brainfuck][1]-derivative virtual machine / interpreter written in C#.

## Syntax

All of the core commands of brainfuck have direct equivalents to brainfcsk, but are implemented using C# overloadable operators.

| Brainfcsk | Brainfuck | Description |
|-----------|-----------|-------------|
| `%` | `.` | Write a byte to the console.
| `/` | `,` | Read a byte from the console.
| `!` | `>` | Increment the pointer.
| `~` | `<` | Decrement the pointer.
| `+` | `+` | Increment the value under the pointer.
| `-` | `-` | Decrement the value under the pointer.
| `[`…`]` | `[`…`]` | Loop while the value under the pointer is non-zero.

However, because C# operators are either unary or binary, a programmer often needs to resort to certain tricks to satisfy the C# compiler. Here are a few handy tips:

* `(F)(x => ...)` converts arbitrary C# code into a program fragment; `x` is the VM's current state.
* `A*x` evaluates fragment `A` using `x` as an initial state.
* `(B)A` evaluates fragment `A` using the default state as an initial state (equivalent to `A*new B()`).
* `F._` is a no-op fragment. It's useful as a placeholder or as an 'anchor' for operators. This may also be aliased as simply `_` with `F _ = F._;` or `using static F;`.
* Operators must be 'anchored' with fragments (or the no-op fragment). e.g. `!_`, `_%_`, and `_[_]` are all valid brainfcsk fragments.
* The compiler can easily confuse the `+` and `-` operators for `++` and `--`, respectively. Use white space to force it treat them correctly.
* Tie two terminal fragments together using `A|B`.

 [1]: https://en.wikipedia.org/wiki/Brainfuck