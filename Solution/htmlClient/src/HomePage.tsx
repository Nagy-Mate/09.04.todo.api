import { useEffect, useState } from "react";

function HomePage() {
  const [todos, setTodos] = useState([]);
  const [showAll, setShowAll] = useState<boolean>(false);

  useEffect(() => {
    const dataFetch = async () => {
      try {
        const url = showAll
          ? "http://localhost:5249/list/"
          : "http://localhost:5249/listNotReady/";
        const response = await fetch(url);
        const data = await response.json();
        setTodos(data);
      } catch (error) {
        console.error("Hiba történt az adatok lekérésekor:", error);
      }
    };
    dataFetch();
  }, [showAll]);

  return (
    <>
      <h1>TODOS</h1>
      <label>
        <input
          type="checkbox"
          checked={showAll}
          onChange={(e) => {
            setShowAll(e.target.checked);
          }}
        />
        Összes teendő mutatása
      </label>
      <ul>
        {todos.map((todo) => (
          <li key={todo.id}>{todo.title}</li>
        ))}
      </ul>
    </>
  );
}
export default HomePage;
