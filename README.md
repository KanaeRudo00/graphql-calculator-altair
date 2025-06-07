# GraphQL Altair Calculator

A minimal GraphQL API that supports basic arithmetic operations such as addition, subtraction, multiplication, and division. This project is intended for learning and experimenting with GraphQL queries using the Altair client.

## Features

* Add two numbers
* Subtract two numbers
* Multiply two numbers
* Divide two numbers (with zero division handling)

## How to Use

1. Open the [Altair GraphQL Client] (https://your-domain.com/ui/altair) in your browser (or use the desktop app).

2. In the URL bar, enter your deployed GraphQL endpoint, for example:

   ```
   https://your-domain.com/graphql
   ```

3. Write a query like this:

   ```graphql
   query {
     add(a: 5, b: 3) {
       result
       message
     }
     subtract(a: 10, b: 4) {
       result
       message
     }
     multiply(a: 6, b: 7) {
       result
       message
     }
     divide(a: 20, b: 4) {
       result
       message
     }
   }
   ```

4. Click the "Send" button to run the query and view the results.

> Note: If `b = 0` in a division operation, `message` will return an appropriate warning.
