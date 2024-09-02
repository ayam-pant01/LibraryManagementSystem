export interface CheckoutResponse {
    checkoutId :  number  
    userName :  string  
    checkoutDate :  Date  
    dueDate :  Date  
    numberOfBooks :  number  
}

export interface UserCheckoutResponse {
    checkoutDate :  Date  
    dueDate :  Date  
    numberOfBooks :  number  
    checkoutDetails : CheckoutDetailResponse[]
}

export interface CheckoutDetailResponse{
    bookId:number
    checkoutDetailId: number
    bookTitle: string
    isReturned: boolean
    returnedDate? : Date
}