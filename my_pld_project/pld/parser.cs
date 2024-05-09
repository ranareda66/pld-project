
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                =  0, // (EOF)
        SYMBOL_ERROR              =  1, // (Error)
        SYMBOL_COMMENT            =  2, // Comment
        SYMBOL_NEWLINE            =  3, // NewLine
        SYMBOL_WHITESPACE         =  4, // Whitespace
        SYMBOL_DIVDIV             =  5, // '//'
        SYMBOL_MINUS              =  6, // '-'
        SYMBOL_EXCLAMEQ           =  7, // '!='
        SYMBOL_PERCENT            =  8, // '%'
        SYMBOL_LPAREN             =  9, // '('
        SYMBOL_RPAREN             = 10, // ')'
        SYMBOL_TIMES              = 11, // '*'
        SYMBOL_TIMESTIMES         = 12, // '**'
        SYMBOL_COMMA              = 13, // ','
        SYMBOL_DOT                = 14, // '.'
        SYMBOL_DIV                = 15, // '/'
        SYMBOL_COLON              = 16, // ':'
        SYMBOL_LBRACE             = 17, // '{'
        SYMBOL_RBRACE             = 18, // '}'
        SYMBOL_PLUS               = 19, // '+'
        SYMBOL_LT                 = 20, // '<'
        SYMBOL_EQ                 = 21, // '='
        SYMBOL_EQEQ               = 22, // '=='
        SYMBOL_GT                 = 23, // '>'
        SYMBOL_AS                 = 24, // as
        SYMBOL_BOOLEANLITERAL     = 25, // BooleanLiteral
        SYMBOL_BREAK              = 26, // break
        SYMBOL_CASE               = 27, // case
        SYMBOL_DEFAULT            = 28, // default
        SYMBOL_DEL                = 29, // del
        SYMBOL_DO                 = 30, // do
        SYMBOL_ELIF               = 31, // elif
        SYMBOL_ELSE               = 32, // else
        SYMBOL_FLOAT              = 33, // float
        SYMBOL_FOR                = 34, // for
        SYMBOL_IDENTIFIER         = 35, // Identifier
        SYMBOL_IF                 = 36, // if
        SYMBOL_IMPORT             = 37, // import
        SYMBOL_IN                 = 38, // in
        SYMBOL_INTEGER            = 39, // integer
        SYMBOL_PRINT              = 40, // print
        SYMBOL_STRINGLITERAL      = 41, // StringLiteral
        SYMBOL_SWITCH             = 42, // switch
        SYMBOL_WHILE              = 43, // while
        SYMBOL_BOOLEANLITERAL2    = 44, // <BooleanLiteral>
        SYMBOL_COMPOUND_STATEMENT = 45, // <compound_statement>
        SYMBOL_COND               = 46, // <cond>
        SYMBOL_DEFUALT_CASE       = 47, // <defualt_case>
        SYMBOL_DELETE_STATEMENT   = 48, // <delete_statement>
        SYMBOL_DO_WHILE_STATEMENT = 49, // <do_while_statement>
        SYMBOL_EXP                = 50, // <exp>
        SYMBOL_EXPRESSION         = 51, // <expression>
        SYMBOL_FACTOR             = 52, // <factor>
        SYMBOL_FLOAT2             = 53, // <float>
        SYMBOL_FOR_STATEMENT      = 54, // <for_statement>
        SYMBOL_IDENTIFIER2        = 55, // <Identifier>
        SYMBOL_IF_STATEMENT       = 56, // <if_statement>
        SYMBOL_IMPORT_STATEMENT   = 57, // <import_statement>
        SYMBOL_INTEGER2           = 58, // <integer>
        SYMBOL_LITERAL            = 59, // <literal>
        SYMBOL_MODULE_ALIAS       = 60, // <module_alias>
        SYMBOL_MODULE_NAME        = 61, // <module_name>
        SYMBOL_NUMBER             = 62, // <number>
        SYMBOL_OP                 = 63, // <op>
        SYMBOL_PRINT_STATEMENT    = 64, // <print_statement>
        SYMBOL_PROGRAM            = 65, // <Program>
        SYMBOL_SIMPLE_STATEMENT   = 66, // <simple_statement>
        SYMBOL_STATEMENT          = 67, // <statement>
        SYMBOL_STATEMENT_LIST     = 68, // <statement_list>
        SYMBOL_STRINGLITERAL2     = 69, // <StringLiteral>
        SYMBOL_SWITCH_CASES       = 70, // <switch_cases>
        SYMBOL_SWITCH_STATEMENT   = 71, // <switch_statement>
        SYMBOL_TERM               = 72, // <term>
        SYMBOL_VARIABLEDECLARATOR = 73, // <Variable Declarator>
        SYMBOL_VARIABLEDECS       = 74, // <Variable Decs>
        SYMBOL_WHILE_STATEMENT    = 75  // <while_statement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                             =  0, // <Program> ::= <statement_list>
        RULE_STATEMENT_LIST                                      =  1, // <statement_list> ::= <statement>
        RULE_STATEMENT_LIST2                                     =  2, // <statement_list> ::= <statement_list> <statement>
        RULE_STATEMENT                                           =  3, // <statement> ::= <simple_statement>
        RULE_STATEMENT2                                          =  4, // <statement> ::= <compound_statement>
        RULE_SIMPLE_STATEMENT                                    =  5, // <simple_statement> ::= <Variable Decs>
        RULE_SIMPLE_STATEMENT2                                   =  6, // <simple_statement> ::= <import_statement>
        RULE_SIMPLE_STATEMENT3                                   =  7, // <simple_statement> ::= <print_statement>
        RULE_SIMPLE_STATEMENT4                                   =  8, // <simple_statement> ::= <delete_statement>
        RULE_VARIABLEDECS                                        =  9, // <Variable Decs> ::= <Variable Declarator>
        RULE_VARIABLEDECS_COMMA                                  = 10, // <Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
        RULE_VARIABLEDECLARATOR                                  = 11, // <Variable Declarator> ::= <Identifier>
        RULE_VARIABLEDECLARATOR_EQ                               = 12, // <Variable Declarator> ::= <Identifier> '=' <expression>
        RULE_IDENTIFIER_IDENTIFIER                               = 13, // <Identifier> ::= Identifier
        RULE_IMPORT_STATEMENT_IMPORT                             = 14, // <import_statement> ::= import <module_name>
        RULE_IMPORT_STATEMENT_IMPORT2                            = 15, // <import_statement> ::= import <module_name> <module_alias>
        RULE_MODULE_NAME                                         = 16, // <module_name> ::= <Identifier>
        RULE_MODULE_NAME_DOT                                     = 17, // <module_name> ::= <module_name> '.' <Identifier>
        RULE_MODULE_ALIAS_AS                                     = 18, // <module_alias> ::= as <Identifier>
        RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN                 = 19, // <print_statement> ::= print '(' <expression> ')'
        RULE_PRINT_STATEMENT_PRINT_LPAREN_COMMA_RPAREN           = 20, // <print_statement> ::= print '(' <expression> ',' <expression> ')'
        RULE_DELETE_STATEMENT_DEL                                = 21, // <delete_statement> ::= del <Identifier>
        RULE_COMPOUND_STATEMENT                                  = 22, // <compound_statement> ::= <if_statement>
        RULE_COMPOUND_STATEMENT2                                 = 23, // <compound_statement> ::= <for_statement>
        RULE_COMPOUND_STATEMENT3                                 = 24, // <compound_statement> ::= <while_statement>
        RULE_COMPOUND_STATEMENT4                                 = 25, // <compound_statement> ::= <do_while_statement>
        RULE_COMPOUND_STATEMENT5                                 = 26, // <compound_statement> ::= <switch_statement>
        RULE_IF_STATEMENT_IF_COLON                               = 27, // <if_statement> ::= if <cond> ':' <statement_list>
        RULE_IF_STATEMENT_IF_COLON_ELSE_COLON                    = 28, // <if_statement> ::= if <cond> ':' <statement_list> else ':' <statement_list>
        RULE_IF_STATEMENT_IF_COLON_ELIF_COLON_ELSE_COLON         = 29, // <if_statement> ::= if <cond> ':' <statement_list> elif <cond> ':' <statement_list> else ':' <statement_list>
        RULE_COND                                                = 30, // <cond> ::= <expression> <op> <expression>
        RULE_COND2                                               = 31, // <cond> ::= <literal>
        RULE_COND3                                               = 32, // <cond> ::= <Identifier>
        RULE_OP_LT                                               = 33, // <op> ::= '<'
        RULE_OP_GT                                               = 34, // <op> ::= '>'
        RULE_OP_EQEQ                                             = 35, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                         = 36, // <op> ::= '!='
        RULE_FOR_STATEMENT_FOR_IN_COLON                          = 37, // <for_statement> ::= for <Identifier> in <cond> ':' <statement_list>
        RULE_WHILE_STATEMENT_WHILE_COLON                         = 38, // <while_statement> ::= while <cond> ':' <statement_list>
        RULE_DO_WHILE_STATEMENT_DO_COLON_WHILE                   = 39, // <do_while_statement> ::= do ':' <statement_list> while <cond>
        RULE_SWITCH_STATEMENT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE = 40, // <switch_statement> ::= switch '(' <cond> ')' '{' <switch_cases> <defualt_case> '}'
        RULE_SWITCH_CASES_CASE_COLON_BREAK                       = 41, // <switch_cases> ::= <switch_cases> case <literal> ':' <statement_list> break
        RULE_SWITCH_CASES_CASE_COLON_BREAK2                      = 42, // <switch_cases> ::= case <literal> ':' <statement_list> break
        RULE_DEFUALT_CASE_DEFAULT_COLON_BREAK                    = 43, // <defualt_case> ::= default ':' <statement_list> break
        RULE_EXPRESSION_PLUS                                     = 44, // <expression> ::= <expression> '+' <term>
        RULE_EXPRESSION_MINUS                                    = 45, // <expression> ::= <expression> '-' <term>
        RULE_EXPRESSION                                          = 46, // <expression> ::= <term>
        RULE_TERM_TIMES                                          = 47, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                            = 48, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                        = 49, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                = 50, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                   = 51, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                              = 52, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                   = 53, // <exp> ::= '(' <expression> ')'
        RULE_EXP                                                 = 54, // <exp> ::= <Identifier>
        RULE_EXP2                                                = 55, // <exp> ::= <literal>
        RULE_LITERAL                                             = 56, // <literal> ::= <number>
        RULE_LITERAL2                                            = 57, // <literal> ::= <StringLiteral>
        RULE_LITERAL3                                            = 58, // <literal> ::= <BooleanLiteral>
        RULE_NUMBER                                              = 59, // <number> ::= <integer>
        RULE_NUMBER2                                             = 60, // <number> ::= <float>
        RULE_INTEGER_INTEGER                                     = 61, // <integer> ::= integer
        RULE_FLOAT_FLOAT                                         = 62, // <float> ::= float
        RULE_STRINGLITERAL_STRINGLITERAL                         = 63, // <StringLiteral> ::= StringLiteral
        RULE_BOOLEANLITERAL_BOOLEANLITERAL                       = 64  // <BooleanLiteral> ::= BooleanLiteral
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst, ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);

        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVDIV :
                //'//'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //as
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANLITERAL :
                //BooleanLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEL :
                //del
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELIF :
                //elif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPORT :
                //import
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT :
                //print
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANLITERAL2 :
                //<BooleanLiteral>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPOUND_STATEMENT :
                //<compound_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFUALT_CASE :
                //<defualt_case>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELETE_STATEMENT :
                //<delete_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STATEMENT :
                //<do_while_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT2 :
                //<float>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STATEMENT :
                //<for_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER2 :
                //<Identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STATEMENT :
                //<if_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPORT_STATEMENT :
                //<import_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER2 :
                //<integer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODULE_ALIAS :
                //<module_alias>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODULE_NAME :
                //<module_name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMBER :
                //<number>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRINT_STATEMENT :
                //<print_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SIMPLE_STATEMENT :
                //<simple_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT_LIST :
                //<statement_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL2 :
                //<StringLiteral>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_CASES :
                //<switch_cases>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STATEMENT :
                //<switch_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATOR :
                //<Variable Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECS :
                //<Variable Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE_STATEMENT :
                //<while_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST :
                //<statement_list> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LIST2 :
                //<statement_list> ::= <statement_list> <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <simple_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <compound_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT :
                //<simple_statement> ::= <Variable Decs>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT2 :
                //<simple_statement> ::= <import_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT3 :
                //<simple_statement> ::= <print_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SIMPLE_STATEMENT4 :
                //<simple_statement> ::= <delete_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS :
                //<Variable Decs> ::= <Variable Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS_COMMA :
                //<Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR :
                //<Variable Declarator> ::= <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_EQ :
                //<Variable Declarator> ::= <Identifier> '=' <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER_IDENTIFIER :
                //<Identifier> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMPORT_STATEMENT_IMPORT :
                //<import_statement> ::= import <module_name>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMPORT_STATEMENT_IMPORT2 :
                //<import_statement> ::= import <module_name> <module_alias>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODULE_NAME :
                //<module_name> ::= <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODULE_NAME_DOT :
                //<module_name> ::= <module_name> '.' <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODULE_ALIAS_AS :
                //<module_alias> ::= as <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_PRINT_LPAREN_RPAREN :
                //<print_statement> ::= print '(' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRINT_STATEMENT_PRINT_LPAREN_COMMA_RPAREN :
                //<print_statement> ::= print '(' <expression> ',' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DELETE_STATEMENT_DEL :
                //<delete_statement> ::= del <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUND_STATEMENT :
                //<compound_statement> ::= <if_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUND_STATEMENT2 :
                //<compound_statement> ::= <for_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUND_STATEMENT3 :
                //<compound_statement> ::= <while_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUND_STATEMENT4 :
                //<compound_statement> ::= <do_while_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPOUND_STATEMENT5 :
                //<compound_statement> ::= <switch_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_COLON :
                //<if_statement> ::= if <cond> ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_COLON_ELSE_COLON :
                //<if_statement> ::= if <cond> ':' <statement_list> else ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STATEMENT_IF_COLON_ELIF_COLON_ELSE_COLON :
                //<if_statement> ::= if <cond> ':' <statement_list> elif <cond> ':' <statement_list> else ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expression> <op> <expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND2 :
                //<cond> ::= <literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND3 :
                //<cond> ::= <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STATEMENT_FOR_IN_COLON :
                //<for_statement> ::= for <Identifier> in <cond> ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_STATEMENT_WHILE_COLON :
                //<while_statement> ::= while <cond> ':' <statement_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STATEMENT_DO_COLON_WHILE :
                //<do_while_statement> ::= do ':' <statement_list> while <cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STATEMENT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch_statement> ::= switch '(' <cond> ')' '{' <switch_cases> <defualt_case> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASES_CASE_COLON_BREAK :
                //<switch_cases> ::= <switch_cases> case <literal> ':' <statement_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_CASES_CASE_COLON_BREAK2 :
                //<switch_cases> ::= case <literal> ':' <statement_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFUALT_CASE_DEFAULT_COLON_BREAK :
                //<defualt_case> ::= default ':' <statement_list> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUS :
                //<expression> ::= <expression> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUS :
                //<expression> ::= <expression> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<expression> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <Identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL :
                //<literal> ::= <number>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL2 :
                //<literal> ::= <StringLiteral>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL3 :
                //<literal> ::= <BooleanLiteral>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMBER :
                //<number> ::= <integer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMBER2 :
                //<number> ::= <float>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGER_INTEGER :
                //<integer> ::= integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FLOAT_FLOAT :
                //<float> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRINGLITERAL_STRINGLITERAL :
                //<StringLiteral> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEANLITERAL_BOOLEANLITERAL :
                //<BooleanLiteral> ::= BooleanLiteral
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "In line:" + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected token : " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI
        }
        private void TokenReadEvent(LALRParser pr, TokenReadEventArgs args)
        {

            string info = args.Token.Text + "         " + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }
    }
}
