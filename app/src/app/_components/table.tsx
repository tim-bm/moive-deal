"use client";

import { useCallback, useState } from "react";
import { moiveSerice } from "../_services/movieService.ts";

export interface Row {
  Title?: string | null;
  Year?: string | null;
  FId?: string | null;
  CId?: string | null;
  CinemaPrice?: string | null;
  FilmPrice?: string | null;
}

export const MovieTable = (Props: { rows: Row[] | undefined }) => {
  const [rows, setRows] = useState<Row[] | undefined>(Props.rows);

  const onGetPrice = useCallback(
    async (row: Row, index: number) => {
      const cinemaPrice = (await moiveSerice.getCinemaWorldMovie(row.CId!))
        ?.price;
      const filmPricde = (await moiveSerice.getFilmWorldMoive(row.FId!))?.price;
      const updatedRows = [...rows!];
      updatedRows[index].CinemaPrice = cinemaPrice;
      updatedRows[index].FilmPrice = filmPricde;
      setRows(updatedRows);
    },
    [rows]
  );

  return (
    <div className="w-full p-2">
      <div className="overflow-x-auto">
        <table className="min-w-full table-fixed border border-gray-300 shadow rounded-lg">
          <thead>
            <tr className="bg-gray-200">
              {[
                "Titile",
                "Year",
                "FilmWorld Price",
                "CinemaWorld Price",
                "action",
              ].map((header, idx) => (
                <th
                  key={idx}
                  className="px-4 py-2 text-left text-sm font-medium text-gray-700 border border-gray-300"
                >
                  {header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows?.concat().map((row, rowIndex) => (
              <tr key={rowIndex} className="hover:bg-gray-100">
                <td
                  key={`${rowIndex}-title`}
                  className="px-4 py-2 border border-gray-300 text-sm text-gray-800"
                >
                  {row.Title}
                </td>
                <td
                 key={`${rowIndex}-year`}
                  className="px-4 py-2 border border-gray-300 text-sm text-gray-800"
                >
                  {row.Year}
                </td>
                <td
                 key={`${rowIndex}-fPrice`}
                  className="px-4 py-2 border border-gray-300 text-sm text-gray-800"
                >
                  {row.FilmPrice}
                </td>
                <td
                  key={`${rowIndex}-cPrice`}
                  className="px-4 py-2 border border-gray-300 text-sm text-gray-800"
                >
                  {row.CinemaPrice}
                </td>
                <td
                 key={`${rowIndex}-button`}
                  className="px-4 py-2 border border-gray-300 text-sm text-gray-800"
                >
                  <button
                    onClick={() => onGetPrice(row, rowIndex)}
                    className="px-3 py-1 bg-blue-600 text-white rounded hover:bg-blue-700 text-sm cursor-pointer"
                  >
                    Get Price
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};
