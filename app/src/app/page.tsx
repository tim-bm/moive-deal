// NextJs doesn't support ES6 import style https://github.com/vercel/next.js/issues/46078
// Potential fix but it is overkill for a demo
// another workaround should be to use another SDK generator rather than Kiota
import { MovieTable, Row } from "./_components/table.tsx";
import { moiveSerice } from "./_services/movieService.js";

export default async function Home() {
  const data = await moiveSerice.listMoive();

  const tableData = data?.filmWorld?.map((f) => {
    const matchCinemaMovie = data?.cinemaWorld?.find(
      (c) => c.title === f.title
    );
    const row: Row = {
      Title: f.title,
      Year: f.year,
      FId: f.id,
      CId: matchCinemaMovie?.id,
      CinemaPrice: undefined,
      FilmPrice: undefined,
    };
    return row;
  });

  return (
    <div className="grid grid-rows-[20px_1fr_20px] items-center justify-items-center min-h-screen p-8 pb-20 gap-16 sm:p-20 font-[family-name:var(--font-geist-sans)]">
      <main className="flex flex-col gap-[32px] row-start-2 items-center sm:items-start">
        <MovieTable rows={tableData}></MovieTable>
      </main>
    </div>
  );
}
