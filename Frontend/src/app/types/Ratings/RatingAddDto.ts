export interface RatingAddDto {
    serviceId: number;
    userId: string | null;
    comment: string;
    rating: number;
}

