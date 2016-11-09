// Scanner -- The lexical analyzer for the Scheme printer and interpreter 
using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;
        // Git test - G
        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();
   
                if (ch == -1) {
                    return null;
                }
                else if(isEmptyChar(ch)) { 
                    return getNextToken();
                }
                else if(ch == ';') { //Skip line after semi-colon
                    In.ReadLine();
                    return getNextToken();
                }
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    //TODO don't need peek
                    // TODO: scan a string into the buffer variable buf
                    //TODO to lowercase
                    int i = 0;
                    while (In.Peek() != '"') {
                        buf[i++] = (char) In.Read();
                    }
                    In.Read(); //take out '"' from input stream
                    
                    
                    string token = new String(buf, 0, i+1);
                    token = token.ToLower();
                    return new StringToken(token);
                }

    
                // Integer constants
                else if (isNumber(ch))
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer
                    int temp = In.Peek();
                    while(isNumber(temp)) {
                        int j = In.Read() - '0';
                        i = (i * 10) + j;
                        temp = In.Peek();
                    }

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    return new IntToken(i);
                }
        
                // Identifiers
                else if (isValidIdentifier(ch)) {
                             
                    // TODO: scan an identifier into the buffer
                    int i=0;
                    buf[i] = (char) ch;
                    int temp = In.Peek();
                    while(isValidIdentifier(temp) || isNumber(temp)) {
                        buf[++i] = (char) In.Read();
                        temp = In.Peek();
                    }

                    // make sure that the character following the integer
                    // is not removed from the input stream
                    //TODO lowercase
                    string token = new String(buf, 0, i+1);
                    token = token.ToLower();
                    return new IdentToken(token);
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
        
        private bool isValidIdentifier(int ch) {
            return ((ch >= 'A' && ch <= 'Z')
                            || (ch >= 'a' && ch <='z')
                            || (ch == '!')
                            || (ch >= 36 && ch <= 38) // $, %, &
                            || (ch >= 42 && ch <= 43) // *, +
                            || (ch >= 45 && ch <= 47) // -, . , /
                            || ch == ':'
                            || (ch >= 60 && ch <= 64) // <, =, >, ?, @
                            || (ch >= 94 && ch <= 95) // ^, -
                            || ch == '~'
                );
        }
        
        private bool isNumber(int ch) {
            return (ch >= '0' && ch <= '9');
        }
        
        private bool isEmptyChar(int ch) {
            return (ch>=9 && ch<=13) || ch == 32;
            //Tab, LF, CR, FF , (VT), whitespace characters
        }
        
        //ERROR REPORTING
        //test parse with simple cons 
    }

}

