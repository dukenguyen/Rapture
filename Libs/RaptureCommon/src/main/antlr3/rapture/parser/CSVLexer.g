lexer grammar CSVLexer;

options {
    language  = Java;
}


@header {
package rapture.generated;
}

CHAR
    : '\u0000' .. '\u0009'
    | '\u000b' .. '\u000c'
    | '\u000e' .. '\u0021'
    | '\u0023' .. '\u002b'
    | '\u002d' .. '\uffff'
    ;

COMMA
    : '\u002c'
    ;

DQUOTE
    : '\u0022'
    ;

NEWLINE
    : '\u000d'? '\u000a'    // DOS/Windows(\r\n) + Unix(\n)
    | '\u000d'              // Mac OS 9 and earlier(\r)
    ;

