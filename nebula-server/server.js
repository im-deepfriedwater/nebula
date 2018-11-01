const express = require("express");
const { ApolloServer, gql } = require("apollo-server-express");
const {
  generateProgram,
  runProgram,
  createConstructs,
  parseConstruct,
  parseLink,
} = require("./utils/nebula");

// Construct a schema, using GraphQL schema language
const typeDefs = gql`
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

// Provide resolver functions for your schema fields
const resolvers = {
  Query: {
    compile: (_, { constructs, links, input }) => {
      const program = generateProgram(
        JSON.parse(constructs),
        JSON.parse(links)
      );

      const runProgramWithStdout = () => {
        let stdout = [];
        const log = console.log;
        console.log = (...args) => {
          stdout.push(args.join(" "));
        };
        const output = runProgram(program);
        console.log = log;
        return {
          output,
          stdout: stdout.join("\n"),
        };
      };

      const { output, stdout } = runProgramWithStdout();
      return {
        program,
        stdout,
        input,
        output,
      };
    },
    parse: (_, { program }) => {
      const { constructs, links } = createConstructs(program);
      return {
        constructs: JSON.stringify(constructs.map(con => parseConstruct(con))),
        links: JSON.stringify(links.map(link => parseLink(link))),
      };
    },
  },
};

const server = new ApolloServer({ typeDefs, resolvers, playground: true });

const app = express();
server.applyMiddleware({ app });

const port = 5050;

app.listen({ port }, () =>
  console.log(
    `🚀 Server ready at http://localhost:${port}${server.graphqlPath}`
  )
);
