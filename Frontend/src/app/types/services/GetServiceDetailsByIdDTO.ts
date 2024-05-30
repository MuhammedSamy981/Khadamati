import { GetAllPicturesDTO } from "./GetAllPicturesDTO";
import { GetAllRatingsDTO } from "./GetAllRatingsDTO";

export interface GetServiceDetailsByIdDTO {
    id: number;
    name: string;
    price: number;
    location: string;
    rating: number;
    description: string;
    date: string;
    providerId: string;
    providerName: string;
    providerPhone: string;
    categoryName: string;
    pictures: GetAllPicturesDTO[] | null;
    ratings: GetAllRatingsDTO[] | null;
}



