const express = require("express");
const { ApolloServer } = require("apollo-server-express");
const { schema } = require("./schema");
const { resolvers } = require("./resolvers");

// Construct a schema, using GraphQL schema language

// Provide resolver functions for your schema fields

const server = new ApolloServer({
  typeDefs: schema,
  resolvers,
  playground: true,
});

const app = express();
server.applyMiddleware({ app });

const port = 5050;

app.listen({ port }, () =>
  console.log(
    `🚀 Server ready at http://localhost:${port}${server.graphqlPath}`
  )
);
