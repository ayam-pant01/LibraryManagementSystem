export interface CheckoutResponse {
    checkoutId :  number  
    userName :  string  
    checkoutDate :  Date  
    dueDate :  Date  
    numberOfBooks :  number  
}

export interface CheckoutDetailResponse{
    checkoutDetailId: number
    bookTitle: string
    isReturned: boolean
    returnedDate? : Date
}