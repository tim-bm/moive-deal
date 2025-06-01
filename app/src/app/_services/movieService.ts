import { createMovieApiClient, MovieApiClient } from "@/sdk/movieApiClient.js";
import { AnonymousAuthenticationProvider } from "@microsoft/kiota-abstractions";
import { FetchRequestAdapter } from "@microsoft/kiota-http-fetchlibrary";

class MoiveService {
  private readonly client: MovieApiClient;

  constructor() {
    const authProvider = new AnonymousAuthenticationProvider();
    const adapter = new FetchRequestAdapter(authProvider);
    this.client = createMovieApiClient(adapter);
  }

  async listMoive() {
    const moives = await this.client.moive.get();
    return moives;
  }

  async getFilmWorldMoive(id: string) {
    const movie = await this.client.moive.film.byId(id).get();
    return movie;
  }
  async getCinemaWorldMovie(id: string) {
    const movie = await this.client.moive.cinema.byId(id).get();
    return movie;
  }
}

export const moiveSerice = new MoiveService();
