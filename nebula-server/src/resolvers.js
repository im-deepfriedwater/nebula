const {
  generateProgram,
  runProgram,
  createConstructs,
  parseConstruct,
  parseLink,
} = require("./lib/nebula");

module.exports.resolvers = {
  Query: {
    compile: (_, { constructs, links, input }) => {
      console.log(constructs);
      console.log(links);
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
