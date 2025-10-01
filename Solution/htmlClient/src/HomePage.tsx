import { useEffect, useState } from "react";

function HomePage() {
  const [todos, setTodos] = useState([]);
  useEffect(() => {
    const dataFetch = async () => {
      try {
        const response = await fetch("http://localhost:5249/list/");
        const data = await response.json();
        setTodos(data);
      } catch (error) {
        console.error("Hiba történt az adatok lekérésekor:", error);
      }
    };
    dataFetch();
  }, []);
  return (
    <>
      <h1>TODOS</h1>

      <ul>
        {todos.map((todo) => (
          <li key={todo.id}>{todo.title}</li>
        ))}
      </ul>
    </>
  );
}
export default HomePage;
