const { gql } = require("apollo-server-express");

module.exports.schema = gql`
  type Query {
    compile(constructs: String!, links: String!, input: String): CompileResponse
    parse(program: String!): ParseResponse
  }

  type CompileResponse {
    program: String
    stdout: String
    input: String
    output: String
  }

  type ParseResponse {
    constructs: String
    links: String
  }
`;
