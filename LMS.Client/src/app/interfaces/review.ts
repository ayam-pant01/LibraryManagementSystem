export interface Review {
    reviewId:number,
    reviewerName:string,
    rating:number,
    comment:string,
    reviewDate: Date
}


export interface ReviewForCreateAndUpdateDto {
    bookId:number,
    rating:number,
    comment:string,
    reviewDate: Date
}
