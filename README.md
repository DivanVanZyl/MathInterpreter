At the time of writing, I'm studying an university module about Set Theory. I found this subject very interesting. Especially how it is related to SQL, and how set based operations work.
Therefore, I wanted to write a simple interpreter for set operations, to improve my understanding of Set Theory, data structures, Lexers, Parsers and Interpreters.

I have written a simple math interpreter as a POC, and am in the process of writing the set theory interpreter.

1.  The Lexer translates text into tokens.
2.  The Parser creates a tree from the tokens.
3.  The Interpreter evaluates the tree.

Example operations:

| Expression    | Result |
| -------- | ------- |
| `{1,2,3} \union {3,4,5}` | `{1,2,3,4,5}` |
| `{1,2,3} \intersect {3,4,5}` | `{3}` |
| `{1,2,3} \diff {3,4,5}` | `{1,2}` |
| `{1,2,3} \symdiff {3,4,5}` | `{1,2,4,5}` |
